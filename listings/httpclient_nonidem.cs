public T add(T obj)
{
    request = WebRequest.Create(protocol+"://" + host + "/" + application_name + "/" + Endpoint) as HttpWebRequest;
    request.Accept = "application/json";
    request.ContentType = "application/json";
    request.Method = "POST";
    ASCIIEncoding encoding = new ASCIIEncoding();
    Byte[] bytes = encoding.GetBytes(JsonConvert.SerializeObject(obj,  serializerSettings));
    Stream newStream = request.GetRequestStream();
    newStream.Write(bytes, 0, bytes.Length);
    var response = request.GetResponse();
    var stream = response.GetResponseStream();
    var sr = new StreamReader(stream);
    var content = sr.ReadToEnd();
    return JsonConvert.DeserializeObject<T>(content);
}