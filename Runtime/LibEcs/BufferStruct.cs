//  Project : ecs
// Contacts : Pix - ask@pixeye.games

using System;
using UnityEngine;

namespace Pixeye.Framework
{
	[Serializable]
	public class BufferStruct<T> where T : struct
	{

		public static BufferStruct<T> Instance = new BufferStruct<T>();

		public T[] container = new T[12];
		public int length;

		public ref T this[int index] => ref container[index];

		public void Add(T obj)
		{
			if (length == container.Length)
				Array.Resize(ref container, length << 1);

			container[length++] = obj;
		}

		public void RemoveAt(int index)
		{
			--length;
			for (int i = index; i < length; ++i)
				SetElement(i, ref container[i + 1]);
		}

		public void SetElement(int index, ref T arg)
		{
			container[index] = arg;
		}

		public ref T Add()
		{
			if (length == container.Length)
				Array.Resize(ref container, length << 1);

			return ref container[length++];
		}

	}
}