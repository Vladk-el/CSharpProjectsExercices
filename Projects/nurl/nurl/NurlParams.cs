/*
 * Created by SharpDevelop.
 * User: Vladk
 * Date: 28/05/2014
 * Time: 22:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace nurl
{
	/// <summary>
	/// Description of NurlParams.
	/// </summary>
	/// 
	public class NurlParams
	{
		public NurlParams()
		{
		}
		
		public string SelectNurlByParameters(string[] array)
		{
			Nurl nurl = new Nurl();
			
			try{
				for(int i = 0; i < array.Length; i++){
					Console.WriteLine(i + " : " + array[i]);
					if(array[i] == "get"){
						Console.WriteLine("get is here !");
						if(array[i+1] == "-url"){
							
							if((array[i+2].StartsWith("\"") || array[i+2].EndsWith("\""))  && array[i+2].Length > 2){
								if(i+3 == array.Length){
									//Console.WriteLine("GET URL");
									return "GET URL";
									//new Nurl(array[i+2].Replace("\"", ""));
									//return nurl.ShowTheContentOfAWebPage(array[i+2].Replace("\"", ""));
								}
								else if(i+5 == array.Length){
									if(array[i+3] == "-save"){
										if((array[i+4].StartsWith("\"") || array[i+4].EndsWith("\"")) && array[i+4].Length > 2){
											//Console.WriteLine("GET URL SAVE");
											return "GET URL SAVE";
											//new Nurl(array[i+2].Replace("\"", ""), array[i+4].Replace("\"", ""));
										}
										else{
											//Console.WriteLine("ERROR : USAGE get -url \"YourUrl\" -save \"fileName\"");
											return "ERROR : USAGE get -url \"YourUrl\" -save \"fileName\"";
										}
									}
								}
							}
							else{
								//Console.WriteLine("ERROR : USAGE get -url \"YourUrl\"");
								return "ERROR : USAGE get -url \"YourUrl\"";
							}
						}
					}
					else if(array[i] == "test"){
						Console.WriteLine("test is here !");
						if(array[i+1] == "-url"){
							if((array[i+2].StartsWith("\"") || array[i+2].EndsWith("\""))  && array[i+2].Length > 2){
								Console.WriteLine("-url OK");
								if(array[i+3] == "-times"){
									
									if(i+5 == array.Length){
										if(Convert.ToInt32(array[i+4]) > 0){
											//Console.WriteLine("TEST URL");
											return "TEST URL";
											//new Nurl(array[i+2].Replace("\"", ""), Convert.ToInt32(array[i+4]), false);
										}
										else{
											//Console.WriteLine("ERROR : USAGE test -url \"YourUrl\" -times numberOfTimeYouWantToTest");
											return "ERROR : USAGE test -url \"YourUrl\" -times numberOfTimeYouWantToTest";
										}
									}
									else if(i+6 == array.Length){
										if(array[i+5] == "-avg"){
											//Console.WriteLine("TEST URL AVG");
											return "TEST URL AVG";
											//new Nurl(array[i+2].Replace("\"", ""), Convert.ToInt32(array[i+4]), true);
										}
										else{
											//Console.WriteLine("ERROR : USAGE test -url \"YourUrl\" -times numberOfTimeYouWantToTest -AVG");
											return "ERROR : USAGE test -url \"YourUrl\" -times numberOfTimeYouWantToTest -AVG";
										}
									}
								}
							}
						}
					}
				}
			}catch(IndexOutOfRangeException e){
				
			}
			
			
			return "ERROR : USAGE get -url \"youUrl\" [-save \"youFile\"] OR test -url \"youUrl\" -times numberOfTimeYouWantToTest [-avg]";
		}
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello NurlParams !");
			
			NurlParams param = new NurlParams();
			
			string[] array = param.testBadSize();
			
			Console.WriteLine(param.SelectNurlByParameters(array));

			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
		public string[] testGetUrl(){
			string[] array = new string[4];
			array[0] = "nurl.exe";
			array[1] = "get";
			array[2] = "-url";
			array[3] = "\"http://fake\"";
			
			return array;
		}
		
		public string[] testGetUrlBad(){
			string[] array = new string[4];
			array[0] = "nurl.exe";
			array[1] = "get";
			array[2] = "-url";
			array[3] = "http://fake";
			
			return array;
		}
		
		public string[] testGetUrlSave(){
			string[] array = new string[6];
			array[0] = "nurl.exe";
			array[1] = "get";
			array[2] = "-url";
			array[3] = "\"http://fake\"";
			array[4] = "-save";
			array[5] = "\"fake.txt\"";
			
			return array;
		}
		
		public string[] testGetUrlSaveBad(){
			string[] array = new string[6];
			array[0] = "nurl.exe";
			array[1] = "get";
			array[2] = "-url";
			array[3] = "\"http://fake\"";
			array[4] = "-save";
			array[5] = "fake.txt";
			
			return array;
		}
		
		public string[] testTestUrl(){
			string[] array = new string[6];
			array[0] = "nurl.exe";
			array[1] = "test";
			array[2] = "-url";
			array[3] = "\"http://fake\"";
			array[4] = "-times";
			array[5] = "5";
			
			return array;
		}
		
		public string[] testTestUrlBad(){
			string[] array = new string[6];
			array[0] = "nurl.exe";
			array[1] = "test";
			array[2] = "-url";
			array[3] = "\"http://fake\"";
			array[4] = "-times";
			array[5] = "0";
			
			return array;
		}
		
		public string[] testTestUrlAverage(){
			string[] array = new string[7];
			array[0] = "nurl.exe";
			array[1] = "test";
			array[2] = "-url";
			array[3] = "\"http://fake\"";
			array[4] = "-times";
			array[5] = "5";
			array[6] = "-avg";
			
			return array;
		}
		
		public string[] testTestUrlAverageBad(){
			string[] array = new string[7];
			array[0] = "nurl.exe";
			array[1] = "test";
			array[2] = "-url";
			array[3] = "\"http://fake\"";
			array[4] = "-times";
			array[5] = "5";
			array[6] = "-average";
			
			return array;
		}
		
		public string[] testBadSize(){
			string[] array = new string[2];
			array[0] = "nurl.exe";
			array[1] = "test";
			
			return array;
		}
	}
}
