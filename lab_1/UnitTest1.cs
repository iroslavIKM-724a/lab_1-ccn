using System;
using System.Collections.Generic;
using Xunit;

namespace lab_1
{

    public class Variant4Service
    {
      
        public List<int> GetDivisors(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Число должно быть больше нуля.", nameof(number));
            }

            List<int> divisors = new List<int>();
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                }
            }
            return divisors;
        }

        
        public int FindMax(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException("Массив не может быть пустым или null.", nameof(array));
            }

            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }
    }


    public class Lab1
    {
        private readonly Variant4Service _service = new Variant4Service();

        #region Тесты для GetDivisors

        [Theory]
        [InlineData(12, new int[] { 1, 2, 3, 4, 6, 12 })]
        [InlineData(7, new int[] { 1, 7 })]
        [InlineData(1, new int[] { 1 })]
        public void GetDivisors_ValidNumber_ReturnsCorrectDivisors(int number, int[] expected)
        {
            List<int> result = _service.GetDivisors(number);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void GetDivisors_ZeroOrNegative_ThrowsArgumentException(int number)
        {
            Assert.Throws<ArgumentException>(() => _service.GetDivisors(number));
        }

        #endregion

        #region Тесты для FindMax

        [Fact]
        public void FindMax_ValidArray_ReturnsMaxElement()
        {
            int[] numbers = { 3, 7, 2, 9, 5 };
            int result = _service.FindMax(numbers);
            Assert.Equal(9, result);
        }

        [Fact]
        public void FindMax_ArrayWithNegativeNumbers_ReturnsMaxElement()
        {
            int[] numbers = { -10, -3, -50, -1 };
            int result = _service.FindMax(numbers);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void FindMax_EmptyArray_ThrowsArgumentException()
        {
            int[] emptyArray = Array.Empty<int>();
            Assert.Throws<ArgumentException>(() => _service.FindMax(emptyArray));
        }

        #endregion
    }
}