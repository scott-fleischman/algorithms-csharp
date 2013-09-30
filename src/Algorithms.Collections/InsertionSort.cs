﻿using System.Collections.Generic;

namespace Algorithms.Collections
{
	public sealed class InsertionSort : IListSortAlgorithm
	{
		// Ch 2.1, p.18
		public void SortByAlgorithm<T>(IList<T> list, IComparer<T> comparer)
		{
			if (list.Count < 2)
				return;

			for (int currentIndex = 1; currentIndex < list.Count; currentIndex++)
			{
				T currentItem = list[currentIndex];

				int insertIndex = currentIndex - 1;
				while (insertIndex >= 0 && comparer.Compare(list[insertIndex], currentItem) > 0)
				{
					list[insertIndex + 1] = list[insertIndex];
					insertIndex--;
				}
				list[insertIndex + 1] = currentItem;
			}
		}

		// Ex 2.3-4
		public static void SortRecursiveInPlace<T>(IList<T> list, IComparer<T> comparer)
		{
			SortRecursiveInPlace(list, list.Count - 1, comparer);
		}

		private static void SortRecursiveInPlace<T>(IList<T> list, int index, IComparer<T> comparer)
		{
			if (index <= 1)
				return;

			SortRecursiveInPlace(list, index - 1, comparer);

			T value = list[index];
			list.RemoveAt(index);

			int insertionIndex = FindInsertionIndex(list, index, value, comparer);
			list.Insert(insertionIndex, value);
		}

		private static int FindInsertionIndex<T>(IList<T> list, int startIndex, T value, IComparer<T> comparer)
		{
			for (int index = startIndex - 1; index > 0; index--)
			{
				if (comparer.Compare(list[index], value) <= 0)
					return index;
			}

			return 0;
		}
	}
}
