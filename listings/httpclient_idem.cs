public T getById(int id)
{
    request = WebRequest.Create(protocol+"://" + host + "/" + application_name + "/" + Endpoint + "/" + id) as HttpWebRequest;
    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    WebHeaderCollection header = response.Headers;
    string response_text = "";
    var encoding = ASCIIEncoding.ASCII;
    using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
    {
        response_text = reader.ReadToEnd();
    }
    return JsonConvert.DeserializeObject<T>(response_text, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd hh:mm:ss" });
}