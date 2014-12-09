using System;
using System.Net;
using System.Text;
using System.IO;

class Program
{
    static void Main()
    {
        // Example :   HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://domain.freshdesk.com/helpdesk/tickets/1/pick_tickets.json"); 
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://domain.freshdesk.com/helpdesk/tickets/[id]/pick_tickets.json"); 
        //HttpWebRequest class is used to Make a request to a Uniform Resource Identifier (URI).  
        request.ContentType = "application/json"; 
        // Set the ContentType property of the WebRequest. 
        request.Method = "PUT"; 
        
        string authInfo = "Api_key:X";
        authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
        request.Headers["Authorization"] ="Basic "+authInfo;

        WebResponse response = request.GetResponse(); 
        // Get the stream containing content returned by the server.
        // Send the request to the server by calling GetResponse. 
        Stream dataStream = response.GetResponseStream(); 
        // Open the stream using a StreamReader for easy access. 
        StreamReader reader = new StreamReader(dataStream); 
        // Read the content. 
        string Response = reader.ReadToEnd(); 
        //return the response 
        Console.Out.WriteLine(Response);

    }
}