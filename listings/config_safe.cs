private void btn_save_config_Click(object sender, EventArgs e)
{
    configuration_store.school_begin_time = txtbox_begin_time.Text;
    configuration_store.backend_entry_endpoint = txtbox_endpoint.Text.ToLower();
    int.TryParse(txtbox_lesson_length.Text, out configuration_store.lesson_length);
    configuration_store.backend_port = txtbox_port.Text;
    configuration_store.backend_address = txtbox_server_ip.Text;
    configuration_store.reload_config();
    configuration_store.config_writeback();
    if (!configLoaded && RepositoryUtility.refreshData()) 
		materialTabControl1.SelectedTab = materialTabControl1.TabPages[0];
    this.refreshInterfaceData();
}