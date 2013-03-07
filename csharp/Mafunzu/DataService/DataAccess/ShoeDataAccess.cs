using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;

namespace DataService.DataAccess
{
    public class ShoeDataAccess
    {
        internal static Func<IDataContext> ResolveDataContext = () => new DataContextAdapter(new DbDataContext());

        internal static Func<RunDataAccess> ResolveRunDataAccess = () => new RunDataAccess();

        public ShoeDataAccess()
        {
            DataContext = ResolveDataContext();   
        }

        private IDataContext DataContext { get; set; }

        private IEnumerable<Shoe> DoGetShoes(Athlete athlete)
        {
            var shoes = DataContext.Queryable<Shoe>().Where(x => x.Athlete == athlete);
            var rundataAcess = ResolveRunDataAccess();
            foreach (var shoe in shoes)
            {
                var runs = rundataAcess.GetRuns(athlete).Where(y => y.Shoe.Equals(shoe));
                shoe.Usage =
                    runs.Count() == 0 ? 0 : runs.Select(x => x.Distance).Sum();
                yield return shoe;
            }
        }

        public ShoePage GetShoePage(ShoePage page)
        {
            IEnumerable<Shoe> shoes = GetShoes(page.Athlete);
            if(page.Active)
            {
                shoes = shoes.Where(shoe => shoe.Active);
            }
            var pager = new Pager<Shoe>(shoes.AsQueryable(), page.Start,page.PageSize);
            page.Shoes = pager.GetPagedItems().ToList();
            return page;
        }

        public List<Shoe> GetShoes(Athlete athlete)
        {
            if (athlete.ID <= 0)
            {
                Error.ObjectIdShouldNotBeZero(athlete);
            }
            return DoGetShoes(athlete).ToList();
        }


        private void DoSaveShoe(Shoe shoe)
        {
            if (shoe.ID > 0)
            {
                DataContext.UpdateAndAttach(shoe);
            }
            else
            {
                DataContext.InsertOnSubmit(shoe);
            }
            DataContext.Commit();
        }

        public void SaveShoe(Shoe shoe)
        {
            var message = string.Format("saveshoe, shoe ID = {0}, AthleteID = {1}", shoe.ID, shoe.AthleteID);
            DataContext.RollbackAndAttach(shoe.Athlete);
            DoSaveShoe(shoe);
        }

        private List<Shoe> SaveShoes(Athlete attachedAthlete, IEnumerable<Shoe> shoes)
        {
            foreach (var shoe in shoes)
            {
                shoe.Athlete = attachedAthlete;
                DoSaveShoe(shoe);
            }
            return GetShoes(attachedAthlete);
            
        }

        public List<Shoe> SaveShoes(List<Shoe> shoes)
        {
            if(shoes.Count==0)
            {
                throw new InvalidOperationException("Cannot save empty list. Must resolve Athlete");
            }
            var athlete = shoes[0].Athlete;
            DataContext.RollbackAndAttach(athlete);
            return SaveShoes(athlete, shoes);
        }

        public void DeleteShoes(List<Shoe> shoes)
        {
            if (shoes.Count == 0)
            {
                return;
            }
            var findFirst = shoes.Find(x => x.Usage > 0);
            if(findFirst!=null)
            {
                throw  new InvalidOperationException("Cannot delete shoe in use");
            }
            foreach (var shoe in shoes)
            {
                DataContext.RollbackAndAttach(shoe);
                DataContext.DeleteOnSubmit(shoe);
            } 
            DataContext.Commit();
        }

        public List<Shoe> DeleteAndUpdateShoes(List<DbOperation> shoes)
        {
            if(shoes.Count==0)
            {
                throw new InvalidOperationException("no shoes to update or delete");
            }

            var deletedShoes = shoes.Where(x => x.Delete).Select(x => x.Data).Cast<Shoe>();
            var newOrUpdatedShoes = shoes.Select(x => x.Data).Cast<Shoe>().Except(deletedShoes);

            var athlete = deletedShoes.Count()> 0 ? deletedShoes.First().Athlete : newOrUpdatedShoes.First().Athlete;
            DataContext.RollbackAndAttach(athlete);

            DeleteShoes(deletedShoes.ToList());

            return newOrUpdatedShoes.Count()==0 ? GetShoes(athlete) : SaveShoes(athlete, newOrUpdatedShoes);
        }

    }
}
