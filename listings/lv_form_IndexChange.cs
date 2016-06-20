 private void lv_form_SelectedIndexChanged(object sender, EventArgs e)
 {
    Model.Form selected = null;
    ListView.SelectedListViewItemCollection selectedItem = 
    lv_form.SelectedItems;
      foreach (ListViewItem li in selectedItem)
         selected = (Model.Form)li.Tag;
     studentList.Items.Clear();
     studentList.Columns.Clear();
     if (selected != null)
     {
         studentList.Columns.Add("Student (" + selected.name + ")", 
         studentList.Width - 20);
         foreach (Student s in selected.getStudents())
         {
             Console.WriteLine(s.getSurname());
             ListViewItem stud = new ListViewItem();
             stud.Tag = s;
             stud.Text = s.getGivenname() + "," + s.getSurname();
             studentList.Items.Add(stud);
         }
     }
     studentList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
 }