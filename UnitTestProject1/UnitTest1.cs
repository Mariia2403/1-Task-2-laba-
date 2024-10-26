using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ToSecSinceMidnight_ShouldReturnCorrectSeconds()
        {
            // Arrange
            MyTime time = new MyTime(8, 10, 16);

            // Act
            int result = time.ToSecSinceMidnight();

            // Assert
            Assert.AreEqual(29416, result); // 8*3600 + 10*60 + 16 = 29416
        }
        // [TestMethod]

        [TestMethod]
        public void FromSecSinceMidnight_ShouldReturnCorrectTime()
        {
            // Arrange
            int seconds = 29416;

            // Act
            MyTime time = new MyTime(0, 0, 0).FromSecSinceMidnight(seconds);

            // Assert
            Assert.AreEqual(8, time.Hour);
            Assert.AreEqual(10, time.Minute);
            Assert.AreEqual(16, time.Second);

        }
        [TestMethod]
        public void AddOneSecond_ShouldIncrementTimeByOneSecond()
        {
            // Arrange
            MyTime time = new MyTime(23, 59, 59);

            // Act
            MyTime result = time.AddOneSecond();

            // Assert
            Assert.AreEqual(0, result.Hour);
            Assert.AreEqual(0, result.Minute);
            Assert.AreEqual(0, result.Second);

        }
        [TestMethod]
        public void AddSeconds_ShouldAddPositiveSecondsCorrectly()
        {
            // Arrange
            MyTime time = new MyTime(10, 30, 00);

            // Act
            MyTime result = time.AddSeconds(10);

            // Assert
            Assert.AreEqual(10, result.Hour);
            Assert.AreEqual(30, result.Minute);
            Assert.AreEqual(10, result.Second);
        }
        [TestMethod]
        public void Difference_ShouldReturnCorrectDifferenceInSeconds()
        {
            // Arrange
            MyTime time1 = new MyTime(12, 30, 30);
            MyTime time2 = new MyTime(10, 15, 15);

            // Act
            int result = time1.Difference(time2);

            // Assert
            Assert.AreEqual(8115, result); // (2*3600 + 15*60 + 15)
        }
        [TestMethod]
        public void IsInRange_ShouldReturnTrueIfTimeIsInRange()
        {
            // Arrange
            MyTime start = new MyTime(22, 0, 0);
            MyTime finish = new MyTime(6, 0, 0);
            MyTime timeInRange = new MyTime(23, 30, 0);
            MyTime timeNotInRange = new MyTime(20,0,0);


            // Act
            bool result = timeInRange.IsInRange(start, finish);
            bool result_2 = timeInRange.IsInRange(finish, start);

            // Assert
            Assert.IsTrue(result);
            Assert.IsFalse(result_2);
        }
        [TestMethod]
        public void WhatLesson_ShouldReturnCorrectLessonOrBreakInfo()
        {
            // Arrange
            MyTime lessonTime = new MyTime(9, 0, 0); // during the 1st lesson
            MyTime breakTime = new MyTime(9, 20, 0); // during break between 1st and 2nd lessons

            // Act
            string lessonResult = lessonTime.WhatLesson();
            string breakResult = breakTime.WhatLesson();

            // Assert
            Assert.AreEqual("1-а пара", lessonResult);
            Assert.AreEqual("перерва мiж 1-ю i 2-ю", breakResult);
        }
    }
}
