'''
Created on Dec 27, 2012

@author: pew
'''
import unittest

from puzzle.nearestpoints import PointEvaluator,Point


text = "g fmnc wms bgblr rpylqjyrc gr zw fylb. rfyrq ufyr amknsrcpq ypc dmp. bmgle gr gl zw fylb gq glcddgagclr ylb rfyr'q ufw rfgq rcvr gq qm jmle. sqgle qrpgle.kyicrpylq() gq pcamkkclbcb. lmu ynnjw ml rfc spj."

class PointTest(unittest.TestCase):
    def testDistance(self):
        point = Point(3,4)
        self.assertEqual(5, point.distanceFromZero())


class DistTest(unittest.TestCase):
    
    def testBasicListBehaviour(self):
        numbers = range(0,100)
        indexOfLastElement = -1
        self.assertEqual(99, numbers[indexOfLastElement])
        self.assertEqual(0, numbers[0])
        self.assertEqual(100,len(numbers))


    def testAddIfBetterWhenListIsNotFull(self):
        n = PointEvaluator()
        numbers = range(0,PointEvaluator.BEST_POINTS_LIST_LENGTH-1)
        numbers = n.addIfBetter(numbers, 200)
        self.assertEqual(200,numbers[-1])

    def testAddIfBetter(self):
        n = PointEvaluator()
        numbers = range(0,99)
        numbers.append(200)
        n.addIfBetter(numbers, 100)
        self.assertEqual(100,numbers[-1])

    def testDist(self):
        n = PointEvaluator()
        x = n.dist(3,4)
        self.assertEqual(25,x)
        pass


if __name__ == "__main__":
    #import sys;sys.argv = ['', 'Test.testDist']
    unittest.main()