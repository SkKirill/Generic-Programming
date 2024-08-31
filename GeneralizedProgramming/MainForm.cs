using GeneralizedProgramming.Model;
using GeneralizedProgramming.Lists;
using System;
using GeneralizedProgramming.Utilites;
using System.Collections.Immutable;

namespace GeneralizedProgramming
{
	public partial class MainForm : Form
	{
		private Interfaces.IList<int> _mainListInt = new ArrayList<int>();
		private Interfaces.IList<string> _mainListString;
		private Interfaces.IList<Film> _mainListFilm;
		public MainForm()
		{
			InitializeComponent();
			ChangeDataListComboBox.SelectedIndex = 0;
			ChangeTypeListComboBox.SelectedIndex = 0;
		}

		private void ChangeTypeList_SelectedIndexChanged(object sender, EventArgs e)
		{
			CreateTree();
			EnterTextBox.Text = string.Empty;
			EnterTextBox.Select();
		}
		private void ChangeDataListComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			CreateTree();
			EnterTextBox.Text = string.Empty;
			EnterTextBox.Select();
		}

		private void CreateTree()
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						if (ChangeTypeListComboBox.SelectedIndex == 0)
						{ _mainListInt = new ArrayList<int>(); }
						else _mainListInt = new Lists.Linked.LinkedList<int>();
						break;
					case 1:
						if (ChangeTypeListComboBox.SelectedIndex == 0)
						{ _mainListString = new ArrayList<string>(); }
						else _mainListString = new Lists.Linked.LinkedList<string>();
						break;
					case 2:
						if (ChangeTypeListComboBox.SelectedIndex == 0)
						{ _mainListFilm = new ArrayList<Film>(); }
						else _mainListFilm = new Lists.Linked.LinkedList<Film>();
						break;
					default:
						throw new NotImplementedException();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
		}

		private void AddListButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						_mainListInt.Add(Convert.ToInt32(EnterTextBox.Text));
						break;
					case 1:
						_mainListString.Add(Convert.ToString(EnterTextBox.Text));
						break;
					case 2:
						_mainListFilm.Add(Film.Parse(EnterTextBox.Text));
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
		}

		private void ClearListButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						_mainListInt.Clear();
						break;
					case 1:
						_mainListString.Clear();
						break;
					case 2:
						_mainListFilm.Clear();
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
		}

		private void ConteinsListButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						MessageBox.Show(_mainListInt.Contains(Convert.ToInt32(EnterTextBox.Text)).ToString(), "Ответ!");
						break;
					case 1:
						MessageBox.Show(_mainListString.Contains(EnterTextBox.Text).ToString(), "Ответ!");
						break;
					case 2:
						MessageBox.Show(_mainListFilm.Contains(Film.Parse(EnterTextBox.Text)).ToString(), "Ответ!");
						break;
					default:
						throw new NotImplementedException();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
			EnterTextBox.Text = string.Empty;
			EnterTextBox.Select();
		}

		private void IndexOfListButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						MessageBox.Show(_mainListInt.IndexOf(Convert.ToInt32(EnterTextBox.Text)).ToString(), "Ответ!");
						break;
					case 1:
						MessageBox.Show(_mainListString.IndexOf(EnterTextBox.Text).ToString(), "Ответ!");
						break;
					case 2:
						MessageBox.Show(_mainListFilm.IndexOf(Film.Parse(EnterTextBox.Text)).ToString(), "Ответ!");
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
		}

		private void InsertListButton_Click(object sender, EventArgs e)
		{
			try
			{
				string[] str = EnterTextBox.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						_mainListInt.Insert(Convert.ToInt32(str[0]), Convert.ToInt32(str[0]));
						break;
					case 1:
						_mainListString.Insert(Convert.ToInt32(str[0]), str[1]);
						break;
					case 2:
						_mainListFilm.Insert(Convert.ToInt32(str[0]), Film.Parse(str[1] + str[2]));
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
		}

		private void RemoveListButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						_mainListInt.Remove(Convert.ToInt32(EnterTextBox.Text));
						break;
					case 1:
						_mainListString.Remove(EnterTextBox.Text);
						break;
					case 2:
						_mainListFilm.Remove(Film.Parse(EnterTextBox.Text));
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
		}

		private void RemoveAtListButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						_mainListInt.RemoveAt(Convert.ToInt32(EnterTextBox.Text));
						break;
					case 1:
						_mainListString.RemoveAt(Convert.ToInt32(EnterTextBox.Text));
						break;
					case 2:
						_mainListFilm.RemoveAt(Convert.ToInt32(EnterTextBox.Text));
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
		}

		private void SubListListButton_Click(object sender, EventArgs e)
		{
			try
			{
				string[] str = EnterTextBox.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						string s = string.Empty;
						foreach (int item in _mainListInt.SubList(Convert.ToInt32(str[0]), Convert.ToInt32(str[1])))
						{
							s = s + item + " ";
						}
						MessageBox.Show(s, "Ответ!");
						break;
					case 1:
						s = string.Empty;
						foreach (string item in _mainListString.SubList(Convert.ToInt32(str[0]), Convert.ToInt32(str[1])))
						{
							s = s + item + " ";
						}
						MessageBox.Show(s, "Ответ!");
						break;
					case 2:
						s = string.Empty;
						foreach (Film item in _mainListFilm.SubList(Convert.ToInt32(str[0]), Convert.ToInt32(str[1])))
						{
							s = s + item + " ";
						}
						MessageBox.Show(s, "Ответ!");
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
		}

		private void CountListButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						MessageBox.Show(_mainListInt.Count.ToString(), "Ответ!");
						break;
					case 1:
						MessageBox.Show(_mainListString.Count.ToString(), "Ответ!");
						break;
					case 2:
						MessageBox.Show(_mainListFilm.Count.ToString(), "Ответ!");
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
		}

		private void thisListButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						MessageBox.Show(_mainListInt[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
						break;
					case 1:
						MessageBox.Show(_mainListString[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
						break;
					case 2:
						MessageBox.Show(_mainListFilm[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}

		}

		private void ExistsUtilsButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						MessageBox.Show(ListUtils.Exists(_mainListInt, item => item > 5).ToString(), "Ответ!");
						break;
					case 1:
						MessageBox.Show(ListUtils.Exists(_mainListString, item => item.Length > 5).ToString(), "Ответ!");
						break;
					case 2:
						MessageBox.Show(ListUtils.Exists(_mainListFilm, item => item.Year > 2004).ToString(), "Ответ!");
						break;
					default:
						throw new NotImplementedException();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
		}

		private void FindUtilsButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						MessageBox.Show(ListUtils.Find(_mainListInt, item => item == Convert.ToUInt32(EnterTextBox.Text)).ToString(), "Ответ!");
						break;
					case 1:
						MessageBox.Show(ListUtils.Find(_mainListString, item => item == EnterTextBox.Text).ToString(), "Ответ!");
						break;
					case 2:
						MessageBox.Show(ListUtils.Find(_mainListFilm, item => item.Name == EnterTextBox.Text).ToString(), "Ответ!");
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
		}

		private void FindLastUtilsButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						MessageBox.Show(ListUtils.FindLast(_mainListInt, item => item == Convert.ToUInt32(EnterTextBox.Text)).ToString(), "Ответ!");
						break;
					case 1:
						MessageBox.Show(ListUtils.FindLast(_mainListString, item => item == EnterTextBox.Text).ToString(), "Ответ!");
						break;
					case 2:
						MessageBox.Show(ListUtils.FindLast(_mainListFilm, item => item.Name == EnterTextBox.Text).ToString(), "Ответ!");
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
		}

		private void FindIndexUtilsButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						MessageBox.Show(ListUtils.FindIndex(_mainListInt, item => item == Convert.ToUInt32(EnterTextBox.Text)).ToString(), "Ответ!");
						break;
					case 1:
						MessageBox.Show(ListUtils.FindIndex(_mainListString, item => item == EnterTextBox.Text).ToString(), "Ответ!");
						break;
					case 2:
						MessageBox.Show(ListUtils.FindIndex(_mainListFilm, item => item.Name == EnterTextBox.Text).ToString(), "Ответ!");
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}

		}

		private void FindLastIndexUtilsButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						MessageBox.Show(ListUtils.FindLastIndex(_mainListInt, item => item == Convert.ToUInt32(EnterTextBox.Text)).ToString(), "Ответ!");
						break;
					case 1:
						MessageBox.Show(ListUtils.FindLastIndex(_mainListString, item => item == EnterTextBox.Text).ToString(), "Ответ!");
						break;
					case 2:
						MessageBox.Show(ListUtils.FindLastIndex(_mainListFilm, item => item.Name == EnterTextBox.Text).ToString(), "Ответ!");
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}

		}

		private void FindAllUtilsButton_Click(object sender, EventArgs e)
		{
/*			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						MessageBox.Show(_mainListInt[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
						break; вавыава
					case 1:
						MessageBox.Show(_mainListString[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
						break; выавыа
					case 2:
						MessageBox.Show(_mainListFilm[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
						break; ываываыв
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}*/

		}

		private void ConvertAllUtilsButton_Click(object sender, EventArgs e)
		{
			/*			try
						{
							switch (ChangeDataListComboBox.SelectedIndex)
							{
								case 0:
									MessageBox.Show(_mainListInt[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
									break; вавыава
								case 1:
									MessageBox.Show(_mainListString[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
									break; выавыа
								case 2:
									MessageBox.Show(_mainListFilm[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
									break; ываываыв
								default:
									throw new NotImplementedException();
							}
							EnterTextBox.Text = string.Empty;
							EnterTextBox.Select();
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, "Ошибка!");
						}
			*/
		}

		private void ForEachUtilsButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						string s = string.Empty;
						ListUtils.ForEach(_mainListInt, (item) => s = s + item.ToString() + " ");
						MessageBox.Show(s, "Ответ!");
						break;
					case 1:
						s = string.Empty;
						ListUtils.ForEach(_mainListString, (item) => s = s + item + " ");
						MessageBox.Show(s, "Ответ!");
						break;
					case 2:
						s = string.Empty;
						ListUtils.ForEach(_mainListFilm, (item) => s = s + item.ToString() + " ");
						MessageBox.Show(s, "Ответ!");
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}

		}

		private void SortUtilsButton_Click(object sender, EventArgs e)
		{
/*			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						MessageBox.Show(_mainListInt[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
						break; вавыава
					case 1:
						MessageBox.Show(_mainListString[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
						break; выавыа
					case 2:
						MessageBox.Show(_mainListFilm[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
						break; ываываыв
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}*/
		}

		private void ChekcForAllUtilsButton_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						MessageBox.Show(_mainListInt[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
						break;
					case 1:
						MessageBox.Show(_mainListString[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
						break;
					case 2:
						MessageBox.Show(_mainListFilm[Convert.ToInt32(EnterTextBox.Text)].ToString(), "Ответ!");
						break;
					default:
						throw new NotImplementedException();
				}
				EnterTextBox.Text = string.Empty;
				EnterTextBox.Select();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
		}

		private void Unmutable_Click(object sender, EventArgs e)
		{
			try
			{
				switch (ChangeDataListComboBox.SelectedIndex)
				{
					case 0:
						_mainListInt = new UnmutableList<int>(_mainListInt);
						break;
					case 1:
						_mainListString = new UnmutableList<string>(_mainListString);
						break;
					case 2:
						_mainListFilm = new UnmutableList<Film>(_mainListFilm);
						break;
					default:
						throw new NotImplementedException();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!");
			}
		}
	}
}
