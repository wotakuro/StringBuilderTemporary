using System.Threading;
using System.Text;

namespace StringBufferTemporary
{
	/// <summary>
	/// 文字列連結周りの処理を、まともにするコードを簡単に書けるためのクラス
	/// string str = "aaa" + 20 + "bbbb"; のようになっているところを…
	/// string str = Sbt.i + "aaa" + 20 + "bbbb"; とすることで、処理が大分まともになります。
	/// 
	/// Sbt.iは、ThreadSafeではありません。あと同じオブジェクトを使いまわします。
    /// 
	/// そういうケースで使いたい場合は、Sbt.Create()を代わりに使用してください
    /// もしくは Sbt.small / Sbt.medium / Sbt.large でも可能です。
    /// この辺りはインスタンスを生成するので安全です
	/// </summary>
	public class Sbt
	{
		private static Sbt s_this;
		private StringBuilder sb;

		static Sbt()
		{
			s_this = new Sbt(1024);
		}
		private Sbt(int capacity)
		{
			sb = new StringBuilder(capacity);
		}

		public static Sbt Create(int capacity)
		{
			return new Sbt(capacity);
		}

        public static Sbt small
        {
            get
            {
                return Create(64);
            }
        }

        public static Sbt medium
        {
            get
            {
                return Create(256);
            }
        }
        public static Sbt large
        {
            get
            {
                return Create(1024);
            }
        }

		public static Sbt i
		{
			get
			{
				s_this.sb.Length = 0;
				return s_this;
			}
		}

		public int Capacity
		{
			set { this.sb.Capacity = value; }
			get { return sb.Capacity; }
		}

		public int Length
		{
			set { this.sb.Length = value; }
			get { return this.sb.Length; }
		}
		public Sbt Remove(int startIndex, int length)
		{
			sb.Remove(startIndex, length);
            return this;
		}
		public Sbt Replace(string oldValue, string newValue)
		{
			sb.Replace(oldValue, newValue);
            return this;
		}

		public override string ToString()
		{
			return sb.ToString();
		}


		public static implicit operator string(Sbt t)
		{
			return t.ToString();
		}

		#region ADD_OPERATOR
		public static Sbt operator +(Sbt t, bool v)
		{
			t.sb.Append(v);
			return t;
		}
		public static Sbt operator +(Sbt t, int v)
		{
			t.sb.Append(v);
			return t;
		}
		public static Sbt operator +(Sbt t,short v){
			t.sb.Append(v);
			return t;
		}
		public static Sbt operator +(Sbt t, byte v)
		{
			t.sb.Append(v);
			return t;
		}
		public static Sbt operator +(Sbt t, float v)
		{
			t.sb.Append(v);
			return t;
		}
		public static Sbt operator +(Sbt t, char c)
		{
			t.sb.Append(c);
			return t;
		}
		public static Sbt operator +(Sbt t, char[] c)
		{
			t.sb.Append(c);
			return t;
		}
		public static Sbt operator +(Sbt t, string str)
		{
			t.sb.Append(str);
			return t;
		}
		public static Sbt operator +(Sbt t, StringBuilder sb)
		{
			t.sb.Append(sb);
			return t;
		}
		#endregion ADD_OPERATOR
	}
}