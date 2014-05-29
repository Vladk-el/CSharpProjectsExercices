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
					if(array[i] == "get"){
						if(array[i+1] == "-url"){
							
							if((array[i+2].StartsWith("\"") || array[i+2].EndsWith("\""))  && array[i+2].Length > 2){
								if(i+3 == array.Length){
									new Nurl(array[i+2].Replace("\"", ""));
									return "GET URL";
								}
								else if(i+5 == array.Length){
									if(array[i+3] == "-save"){
										if((array[i+4].StartsWith("\"") || array[i+4].EndsWith("\"")) && array[i+4].Length > 2){
											new Nurl(array[i+2].Replace("\"", ""), array[i+4].Replace("\"", ""));
											return "GET URL SAVE";
										}
										else{
											return "ERROR : USAGE get -url \"YourUrl\" -save \"fileName\"";
										}
									}
								}
							}
							else{
								return "ERROR : USAGE get -url \"YourUrl\"";
							}
						}
					}
					else if(array[i] == "test"){
						if(array[i+1] == "-url"){
							if((array[i+2].StartsWith("\"") || array[i+2].EndsWith("\""))  && array[i+2].Length > 2){
								if(array[i+3] == "-times"){
									
									if(i+5 == array.Length){
										if(Convert.ToInt32(array[i+4]) > 0){
											new Nurl(array[i+2].Replace("\"", ""), Convert.ToInt32(array[i+4]), false);
											return "TEST URL";
										}
										else{
											return "ERROR : USAGE test -url \"YourUrl\" -times numberOfTimeYouWantToTest";
										}
									}
									else if(i+6 == array.Length){
										if(array[i+5] == "-avg"){
											new Nurl(array[i+2].Replace("\"", ""), Convert.ToInt32(array[i+4]), true);
											return "TEST URL AVG";
										}
										else{
											return "ERROR : USAGE test -url \"YourUrl\" -times numberOfTimeYouWantToTest -AVG";
										}
									}
								}
							}
						}
					}
				}
			}catch(IndexOutOfRangeException){
				
			}
			
			return "ERROR : USAGE get -url \"youUrl\" [-save \"youFile\"] OR test -url \"youUrl\" -times numberOfTimeYouWantToTest [-avg]";
		}
		
		public static void Main(string[] args)
		{	
			NurlParams param = new NurlParams();
			
			//string[] array = param.testGetUrl();
			//param.SelectNurlByParameters(array);
			
			/*foreach(string s in args){
				Console.WriteLine(s);
			}*/
			
			param.SelectNurlByParameters(args);

			/*Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);*/
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

		public string[] testBadArgs(){
			string[] array = new string[6];
			array[0] = "nurl.exe";
			array[1] = "hey";
			array[2] = "-url";
			array[3] = "\"http://fake\"";
			array[4] = "-save";
			array[5] = "\"fake.txt\"";
			
			return array;
		}
	}
}
