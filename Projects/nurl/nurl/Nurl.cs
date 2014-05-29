/*
 * Created by SharpDevelop.
 * User: Vladk
 * Date: 14/05/2014
 * Time: 11:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.IO;

namespace nurl
{
	class Nurl
	{
		
		public Nurl(){
			
		}
		
		public Nurl(string url){
			Console.WriteLine(ShowTheContentOfAWebPage(url));
		}
		
		public Nurl(string url, string fileName){
			SaveTheContentOfAWebPage(url, fileName);
		}
		
		public Nurl(string url, int numberOfTimeToExecute, bool avg){
			if(avg){
				Console.WriteLine(ShowAverageDowloadTimeOfAWebPage(url, numberOfTimeToExecute));
			}
			else{
				Console.WriteLine(ShowDowloadTimeOfAWebPage(url, numberOfTimeToExecute));
			}
		}
		
		public string ShowTheContentOfAWebPage(string url){
			WebClient client = new WebClient();
			string downloadString = "<h1>hello</h1>";
			
			try{
				downloadString = client.DownloadString(url);
			}catch(WebException e){
			}
			
			return downloadString;
		}
		
		public bool SaveTheContentOfAWebPage(string url, string fileName){
			WebClient client = new WebClient();
			string downloadString = "<h1>hello</h1>";
			try{
				downloadString = client.DownloadString(url);
			}catch(WebException e){
			}
			try{
				TextWriter tw = new StreamWriter(fileName);
	            tw.WriteLine(downloadString);
	            tw.Close();
			}catch(Exception e){
				return false;
			} 
			return true;
		}
		
		
		public string ShowDowloadTimeOfAWebPage(string url, int numberOfTimeToExecute){
			string toReturn = "";
			
			for(int i = 0; i < numberOfTimeToExecute; i++){
				toReturn += ShowDowloadTimeOfAWebPage(url) + " ";
			}
			return toReturn;
		}
		
		public double ShowAverageDowloadTimeOfAWebPage(string url, int numberOfTimeToExecute){
			string toReturn = "";
			double averageDownloadedTime = 0;
			
			for(int i = 0; i < numberOfTimeToExecute; i++){
				averageDownloadedTime += ShowDowloadTimeOfAWebPage(url);
			}
			return averageDownloadedTime / numberOfTimeToExecute;
		}
		
		public double ShowDowloadTimeOfAWebPage(string url){
			WebClient client = new WebClient();
			
			try{
				DateTime before = DateTime.Now;
				client.DownloadString(url);
				DateTime after = DateTime.Now;
				TimeSpan time = after - before;
				return time.TotalMilliseconds;
			}catch(WebException e){
				return 0;
			}
		}
		
		
		
	}
}