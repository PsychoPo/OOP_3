using System;

namespace Lab2 // 21. Создать иерархию классов Электронная вычислительная машина, Персональный компьютер, Ноутбук.
					// Класс Электронная вычислительная машина должен содержать атрибуты и методы, общие для производных классов.
					// Основная программа должна создавать массивы объектов производных классов и выводить их на экран.
					// Базовый класс (возможно, абстрактный) с помощью виртуальных или абстрактных методов и свойств должен задавать интерфейс для производных классов.
					// Во всех классах следует переопределить метод Equals, чтобы обеспечить сравнение значений, а не ссылок.
					// Функция Main должна содержать массив из элементов базового класса, заполненный ссылками на производные классы.

{
	abstract class Electronic_Computer
	{
		string name;
		string firma;
		double weight;
		protected Electronic_Computer()
		{
			Name = "Нет информации";
			Firma = "Нет информации";
			Weight = 1.0;
		}
		protected Electronic_Computer(string name, string firma, double weight)
		{
			Name = name;
			Firma = firma;
			Weight = weight;
		}
		public virtual void print()
		{
			Console.WriteLine($"Название: {Name}, фирма: {Firma}, вес: {Weight}.");
		}
		public virtual void scan()
		{
			Console.Write("\nВведите название: ");
			Name = Console.ReadLine()!;
			Console.Write("\nВведите название фирмы производителя: ");
			Firma = Console.ReadLine()!;
			try
			{
				Console.Write("\nВведите вес: ");
				Weight = Double.Parse(Console.ReadLine()!);
			}
			catch (FormatException)
			{
				Console.WriteLine("\nВы ввели символ, введите число!");
				Console.Write("\nВведите вес: ");
				Weight = Double.Parse(Console.ReadLine()!);
			}
		}
		protected string Name
		{
			set
			{
				if (value == "")
					Console.WriteLine("Значение не может быть пустым!\n");
				else
					name = value;
			}
			get { return name; }
		}
		protected string Firma
		{
			set
			{
				if (value == "")
					Console.WriteLine("Значение не может быть пустым!\n");
				else
					firma = value;
			}
			get { return firma; }
		}
		protected double Weight
		{
			set
			{
				if (value < 1)
					Console.WriteLine("Значение не может быть отрицательным!\n");
				else
					weight = value;
			}
			get { return weight; }
		}
		public override bool Equals(Object obj)
		{
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}
			else
			{
				Electronic_Computer p = (Electronic_Computer)obj;
				return (Name == p.Name) && (Firma == p.Firma) && (Weight == p.Weight);
			}
		}
	}
	class PC : Electronic_Computer
	{
		string corpus;

		public PC()
		: base()
		{
			Corpus = "Нет информации";
		}

		public PC(string name, string firma, double weight, string corpus)
		: base(name, firma, weight)
		{
			Corpus = corpus;
		}

		string Corpus
		{
			set
			{
				if (value == "")
					Console.WriteLine("Значение не может быть пустым!\n");
				else
					corpus = value;
			}
			get { return corpus; }
		}

		public override void print()
		{
			Console.WriteLine("Персональный компьютер");
			base.print();
			Console.WriteLine($"Тип корпуса: {Corpus}.\n");
		}
		public override void scan()
		{
			base.scan();
			Console.Write("\nВведите тип корпуса: ");
			Corpus = Console.ReadLine()!;
		}
		public override bool Equals(Object obj)
		{
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}
			else
			{
				PC p = (PC)obj;
				return base.Equals((Electronic_Computer)obj) && (Corpus == p.Corpus);
			}
		}
	}

	class Laptop : Electronic_Computer
	{
		double battery;

		public Laptop()
		: base()
		{
			Battery = 1.0;
		}

		public Laptop(string name, string firma, double weight, double battery)
		: base(name, firma, weight)
		{
			Battery = battery;
		}

		double Battery
		{
			set
			{
				if (value < 1)
					Console.WriteLine("Значение не может быть отрицательным!\n");
				else
					battery = value;
			}
			get { return battery; }
		}

		public override void print()
		{
			Console.WriteLine("Ноутбук");
			base.print();
			Console.WriteLine($"Батарея: {Battery}.\n");
		}
		public override void scan()
		{
			base.scan();
			try
			{
				Console.Write("\nВведите количество батареи: ");
				Battery = Double.Parse(Console.ReadLine()!);
			}
			catch (FormatException)
			{
				Console.WriteLine("\nВы ввели символ, введите число!");
				Console.Write("\nВведите количество батареи: ");
				Battery = Double.Parse(Console.ReadLine()!);
			}
		}
		public override bool Equals(Object obj)
		{
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
			{
				return false;
			}
			else
			{
				Laptop p = (Laptop)obj;
				return base.Equals((Electronic_Computer)obj) && (Battery == p.Battery);
			}
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			Console.Clear();
			Console.Write("\nЦель данной программы заполнение данных о электронных вычислительных машинах с последующим их выводом на экран,");
			Console.Write("а так же вычисление площади и объёма комнат.\n");
			var A = new Electronic_Computer[0];
			int option = 0;
			while (option != 10)
			{
				try
				{
					Console.Write("\n1. Заполнение массива данных;\n2. Сравнение объектов;\n10. ВЫХОД.\nВвод: ");
					option = Convert.ToInt32(Console.ReadLine()!);
				}
				catch (FormatException)
				{
					option = 11;
				}
				switch (option)
				{
					case 1:
						{
							int size = 0;
							try
							{
								Console.Write("\nВведите количество электронных вычислительных машин: ");
								size = Int32.Parse(Console.ReadLine()!);
							}
							catch (FormatException)
							{
								Console.WriteLine("\nВы ввели символ, введите число!");
								Console.Write("\nВведите количество электронных вычислительных машин: ");
								size = Int32.Parse(Console.ReadLine()!);
							}
							A = new Electronic_Computer[size];
							for (int i = 0; i < size; i++)
							{
								int key;
								Console.Write("\nВыберите какой объект создать и заполнить.\n1. Персональный компьютер;\n2. Ноутбук.\nВвод: ");
								key = Int32.Parse(Console.ReadLine()!);
								if (key == 1)
								{
									A[i] = new PC();
									A[i].scan();
								}
								else if (key == 2)
								{
									A[i] = new Laptop();
									A[i].scan();
								}
								else
									Console.WriteLine("\nНеверный ввод. Введите 1 или 2.\n");
							}
							for (int i = 0; i < size; i++)
							{
								Console.WriteLine($"\n№{i + 1}");
								A[i].print();
							}
						}
						break;

					case 2:
						{
							if (A.Length <= 0)
							{
								Console.WriteLine("\nСначала заполните массив!");
								break;
							}
							else if (A.Length == 1)
							{
								Console.WriteLine("\nУ вас только один объект!");
								break;
							}
							try
							{
								int first = 0, second = 0;
								try
								{
									Console.Write("\nВведите номер первого объекта сравнения: ");
									first = Int32.Parse(Console.ReadLine()!);
								}
								catch (FormatException)
								{
									Console.WriteLine("\nВы ввели символ, введите число!");
									Console.Write("\nВведите номер первого объекта сравнения: ");
									first = Int32.Parse(Console.ReadLine()!);
								}
								try
								{
									Console.Write("\nВведите номер второго объекта сравнения: ");
									second = Int32.Parse(Console.ReadLine()!);
								}
								catch (FormatException)
								{
									Console.WriteLine("\nВы ввели символ, введите число!");
									Console.Write("\nВведите номер второго объекта сравнения: ");
									second = Int32.Parse(Console.ReadLine()!);
								}
								if (first == second)
								{
									Console.WriteLine("\nВы выбрали один и тот же объект!");
									break;
								}
								if (A[first - 1].Equals(A[second - 1]))
									Console.WriteLine("\nОбъекты равны!");
								else
									Console.WriteLine("\nОбъекты не равны!");

							}
							catch (IndexOutOfRangeException e)
							{
								Console.WriteLine();
								Console.WriteLine(e.Message);
								Console.WriteLine("Введите правильный номер объекта массива!");
								break;
							}
						}
						break;

					case 10:
						{
							//exit
							break;
						}
					default:
						{
							Console.WriteLine("\nНеверный ввод.\nВведите число 1 или 10.");
							break;
						}
				}
			}
		}
	}
}
