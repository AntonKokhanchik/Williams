using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Williams
{
	public partial class Form1 : Form
	{
		BigInt B = new BigInt(1000000);
		public Form1()
		{
			InitializeComponent();
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			BigInt number = new BigInt(textBoxNumber.Text);
			textBoxDivident.Clear();
			try
			{
				while (number > 1)
				{
					BigInt temp = Factorize(number);
					textBoxDivident.AppendText(temp.ToString() + " ");
					number /= temp;
				}
			}
			catch (MyException)
			{
				textBoxDivident.AppendText("fail");
			}

		}

		private BigInt Factorize(BigInt m)
		{
			if (m == 1)
				return m;
			List<int> table = SimpleTable();

			/*for (int i = 0; i < table.Count(); i++)
				if (GCD(m, new BigInt(table[i])) > 1)
					return new BigInt(table[i]);*/

			BigInt k = new BigInt(1);
			int j = 1;
			for (int i = 0; i < table.Count(); i++)
			{
				if (k * table[i] > B)
					break;
				k *= table[i];
			}

			j = 0;

			while (j < 80)
			{
				j++;
				BigInt a, b;
				Random r = new Random();
				do
				{
					a = new BigInt(r.Next(1, 100000));
					b = new BigInt(r.Next(1, 100000));
				}
				while (GCD(a, b) != 1 || (a * a - b * 4).IsNegative());

				BigInt d = a * a - b * 4;

				BigInt p = GCD(m, b);
				if (p > 1)
					return p;

				p = GCD(m, d);
				if (p > 1)
					return p;

				p = GCD(m, Luke(k, a, b, m));
				if (p > 1)
					return p;
			}
			throw new MyException();
		}

		private List<int> SimpleTable()
		{
			List<int> table = new List<int> { 2, 3, 5, 7, 11, 13, 17 };
			int h = 5, s = 25, p = table.Last(); //h=sqrt(s) или s= h*h

			while (true)
			{
				p += 2;
				int k = 1;
				if (B < p)
					return table;
				if (p > s)
				{
					s += h;
					h += 1;
					s += h;
				}

				bool flag = false;
				while (table[k] <= h)
				{
					if (p % table[k] == 0)
					{
						flag = true;
						break;
					}
					k++;
				}

				if (flag)
					continue;

				table.Add(p);
			}
		}

		/// <summary>
		/// наибольший общий делитель
		/// </summary>
		BigInt GCD(BigInt number1, BigInt number2)
		{
			BigInt a = new BigInt(number1);
			BigInt b = number2, x = new BigInt(0), d = new BigInt(1);
			while (a != 0)
			{
				BigInt q = b / a;
				BigInt y = a;
				a = b % a;
				b = y;
				y = d;
				d = x - q * d;
				x = y;
			}
			return b;
		}

		/// <summary>
		/// находит Uk - k-й член U последовательности Люка с параметрами a и b по модулю m
		/// </summary>
		BigInt Luke (BigInt k, BigInt a, BigInt b, BigInt m)
		{
			BigInt d = a * a - b * 4;
			string kBinary = Binary(k);
			int s = 0, i = 0;

			while (kBinary[i] == '0')
			{
				s++;
				i++;
			}

			BigInt U = new BigInt(1), V = a;
			i++;

			BigInt x, y;
			while (i < kBinary.Length)
			{
				x = U * V;
				y = (V * V + d * U * U) / 2;
				U = x % m;
				V = y % m;

				if (kBinary[i] == '1')
				{
					x = (V + a * U) / 2;
					y = (a*V + d * U) / 2;
					U = x % m;
					V = y % m;
				}

				i++;
			}

			while (s > 0)
			{
				x = U * V;
				y = (V * V + d * U * U) / 2;
				U = x % m;
				V = y % m;

				s--;
			}

			return U;
		}

		/// <summary>
		/// Возвращает бинарное представление большого числа
		/// </summary>
		string Binary (BigInt k)
		{
			BigInt tmp = k;
			string s = "";
			while (tmp != 1)
			{
				s += tmp % 2;
				tmp /= 2;
			}
			s += "1";
			return s;
		}
	}
}
