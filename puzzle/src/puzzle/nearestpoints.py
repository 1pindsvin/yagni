import bisect
import math

class Point(object):
    x = 0
    y = 0
    
    def __init__(self,x,y):
        self.x = x
        self.y = y
    
    def distanceFromZero(self):
        return math.sqrt(self.distanceFromZeroSquared()) 

    def distanceFromZeroSquared(self):
        return self.x * self.x + self.y * self.y 
    

class Heap(object):
    distancesFromZero=[]
    points = {}
    def addPoint(self, point):
        self.distancesFromZero.append(point.distanceFromZero())
        
        self.points[point.distanceFromZero()]=point

    def addPointIfBetter(self,point):
        last = self.distancesFromZero[-1]
        if (point.distanceFromZero < last.distanceFromZero()) :
            bisect.insort(self.distancesFromZero)
            self.distancesFromZero.pop()
            
        


class PointEvaluator(object):
    @staticmethod
    def liftTwo(number):
        return 2^number
    
    BEST_POINTS_LIST_LENGTH = 100
    def dist(self,x, y):
        return x * x + y * y


    def addIfBetter(self,numbers, nextNumber):
        
        if(len(numbers) <= PointEvaluator.BEST_POINTS_LIST_LENGTH):
            numbers.append(nextNumber)
            return numbers
        last = numbers[-1]
        if (nextNumber < last) :
            bisect.insort(numbers, nextNumber)
            numbers.pop()
    
    
    def addPointIfBetter(self, point):
        pass
    


if __name__ == '__main__':
    pass
