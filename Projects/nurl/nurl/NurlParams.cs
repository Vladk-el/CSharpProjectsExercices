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
		
		public NurlParams(string[] array)
		{
			for(int i = 0; i < array.Length; i++){
				Console.WriteLine(i + " : " + array[i]);
				if(array[i] == "get"){
					Console.WriteLine("get is here !");
					if(array[i+1] == "-url"){
						
						if((array[i+2].StartsWith("\"") || array[i+2].EndsWith("\""))  && array[i+2].Length > 2){
							if(i+3 == array.Length){
								Console.WriteLine("GET URL");
								break;
							}
							else if(i+5 == array.Length){
								if(array[i+3] == "-save"){
									if((array[i+4].StartsWith("\"") || array[i+4].EndsWith("\"")) && array[i+4].Length > 2){
										Console.WriteLine("GET URL SAVE");
										break;
									}
									else{
										Console.WriteLine("ERROR : USAGE get -url \"YourUrl\" -save \"fileName\"");
									}
								}
							}
						}
						else{
							Console.WriteLine("ERROR : USAGE get -url \"YourUrl\" ");
						}
						
					}
					
					else if(array[i] == "test"){
						
					}
					
					
				}
			}
		}
		
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello NurlParams !");
			
			NurlParams param = new NurlParams();
			
			string[] array = param.testGetUrlSave();
			
			NurlParams np = new NurlParams(array);

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
		
		public string[] testTestUrl(){
			string[] array = new string[6];
			array[0] = "nurl.exe";
			array[1] = "get";
			array[2] = "-url";
			array[3] = "\"http://fake\"";
			array[4] = "-times";
			array[5] = "5";
			
			return array;
		}
		
		public string[] testTestUrlAverage(){
			string[] array = new string[6];
			array[0] = "nurl.exe";
			array[1] = "get";
			array[2] = "-url";
			array[3] = "\"http://fake\"";
			array[4] = "-times";
			array[5] = "5";
			array[6] = "-avg";
			
			return array;
		}
	}
}
