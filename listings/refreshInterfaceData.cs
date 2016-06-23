public void refreshInterfaceData()
{
    if (RepositoryUtility.refreshData())
    {
        lv_form.Items.Clear();
        lv_form.Columns.Clear();
        lv_form.Columns.Add("Klasse");
        foreach (Model.Form f in RepositoryUtility.getForms())
        {
            ListViewItem name = new ListViewItem();
            name.Tag = f;
            name.Text = f.name;
            lv_form.Items.Add(name);
        }
        lv_form.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        //Incident Liste füllen
        List<Incident> all_incidents = RepositoryUtility.getIncidents();
        lw_cur_Incident.Items.Clear();
        foreach (Incident i in all_incidents)
        {
            if (i.isCurrent())
            {
                ListViewItem inc = new ListViewItem();
                inc.SubItems.Clear();
                inc.SubItems.Add(i.ticket_ID.ToString());
                inc.SubItems.Add(i.arrival);
                inc.SubItems.Add(i.arrival + 15);
                String x = i.student.givenname + " " + i.student.surname;
                inc.SubItems.Add(x);
                inc.Tag = i;
                lw_cur_Incident.Items.Add(inc);
            }
        }
        lw_cur_Incident.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        lw_cur_Incident.Columns[0].Width = 0;
        lw_cur_Incident.Columns[1].Width = 100;
        lw_cur_Incident.Columns[2].Width = 170;
        lw_cur_Incident.Columns[3].Width = 170;
        lw_cur_Incident.Columns[4].Width = 200;

    }
    else
    {
        MessageBox.Show("Error reading data from backend");
    }
}