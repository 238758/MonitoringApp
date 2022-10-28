
string longitude = "aa";
double latitude = 12.1;
string imageUrl = "cc";

string meta = $"metadata: {{ longitude: \"{longitude}\" latitude: \"{latitude}\" imageUrl: \"{imageUrl}\" }}";


string a = $" {{ }}";

Console.WriteLine(meta);