namespace GeneralizedProgramming.Model
{
	public struct Film : IComparable<Film>
	{
		public string Name { get; set; }
		public int Year { get; set; }

		public static Film Parse(string str)
		{
			var data = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			return new Film { Name = data[0], Year = int.Parse(data[1]) };
		}

		public int CompareTo(Film other)
		{
			var nameCompare = Name.CompareTo(other.Name);
			return nameCompare != 0 ? nameCompare : Year.CompareTo(other.Year);
		}

		public override string ToString() => $"{Name} {Year}";
	}
}
