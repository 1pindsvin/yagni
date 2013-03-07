using System;
using System.IO;
using DataService.Model;
using NUnit.Framework;
using Unittests.ActionScriptClasses;

namespace Unittests
{
    [TestFixture]
    public class ActionScriptClassBuilderTester
    {
        private static void WriteTypeToDisk(Type type)
        {
            var path = type.Name + ".as";
            var scriptBuilder = new ActionScriptClassBuilder(type);
            var scriptClass = scriptBuilder.BuildActionScriptType().WithNamespace().Build().ToString();
            File.WriteAllText(path, scriptClass);
        }

        [Test]
        public void AssertBuildsScriptForTableClassType()
        {
            const string expected =
                "\tpublic class TableClass\n\t{\r\n\t\tpublic function TableClass()\n\t\t{\n\t\t}\n\r\n\t\tprivate var _trainingSessions:Array;\n\n\t\tpublic function get TrainingSessions() : Array\n\t\t{\n\t\t\treturn _trainingSessions;\n\t\t}\n\n\t\tpublic function set TrainingSessions(value:Array) : void\n\t\t{\n\t\t\t_trainingSessions = value;\n\t\t}\n\r\n\t\tprivate var _bar:String;\n\n\t\tpublic function get Bar() : String\n\t\t{\n\t\t\treturn _bar;\n\t\t}\n\n\t\tpublic function set Bar(value:String) : void\n\t\t{\n\t\t\t_bar = value;\n\t\t}\n\r\n\t}\n";
            var type = typeof(TableClass);
            var scriptClassBuilder = new ActionScriptClassBuilder(type);
            var clazz = scriptClassBuilder.BuildActionScriptType().Build().ToString();
            Assert.AreEqual(expected, clazz);
        }

        [Test]
        public void AssertResolvesActionScriptMethod()
        {
            const string expected =
                "\tpublic class ClassWithOneMethod\n\t{\r\n\t\tpublic function ClassWithOneMethod()\n\t\t{\n\t\t}\n\r\n\t\tpublic function fooBar(foo:int, bar:Array) : String\n\t\t{\n\t\t}\n\r\n\t}\n";
            var type = typeof(ClassWithOneMethod);
            const bool lowercaseMethods = true;
            var scriptClassBuilder = new ActionScriptClassBuilder(type, lowercaseMethods);
            var clazz = scriptClassBuilder.BuildActionScriptType().Build().ToString();
            Assert.AreEqual(expected, clazz);
        }


        [Test, Category("slow")]
        public void AssertWritesActionScriptToDisk()
        {
            var assembly = typeof(Athlete).Assembly;
            var typeSearcher = new ScriptTypeSearcher(new[] { assembly });
            foreach (var type in typeSearcher.GetTypesWithTableAttribute())
            {
                WriteTypeToDisk(type);
            }
        }

        [Test, Category("slow")]
        public void AssertWritesTypesToDisk()
        {
            var types = new[]
                            {
                                typeof(IEditActivityPresentationModel),
                                typeof(EditActivityPresentationModel),
                                typeof (IWeekdaysPresentationModel),
                                typeof (WeekdaysPresentationModel),
                                typeof (EditTrainingPlanPresentationModel),
                                typeof (IEditTrainingPlanPresentationModel),
                                typeof (IRunChartPresentationModel),
                                typeof (RunChartPresentationModel),
                                typeof (BestRunsPresentationModel),
                                typeof (IBestRunsPresentationModel),
                                typeof (IEditAthletePresentationModel),
                                typeof (EditAthletePresentationModel),
                                typeof(IAthleteHealthHistoryPresentationModel),
                                typeof(AthleteHealthHistoryPresentationModel)
                            };

            foreach (var type in types)
            {
                var path = type.Name + ".as";
                var scriptBuilder = 
                    new ActionScriptClassBuilder(type, true)
                        {
                            NamespaceName = "dk.runtrack.presentationmodels"
                        };
                var scriptClass = scriptBuilder.BuildActionScriptType().WithNamespace().Build().ToString();
                File.WriteAllText(path, scriptClass);
            }
            var notLoweredTypes = new[]
                                      {
                                          typeof (BestRunsQuery),
                                          typeof (AthleteHealthQuery),
                                          typeof(ActivityQuery),
                                          typeof(WorkoutQuery),
                                          typeof (PagingData)
                                      };
            foreach (var type in notLoweredTypes)
            {
                var path = type.Name + ".as";
                var scriptBuilder = new ActionScriptClassBuilder(type, false);
                var scriptClass = scriptBuilder.BuildActionScriptType().WithNamespace().Build().ToString();
                File.WriteAllText(path, scriptClass);
            }
        }
    }
}