/*
 * Created by SharpDevelop.
 * User: Vladk
 * Date: 29/05/2014
 * Time: 12:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using NUnit.Framework;

namespace nurl
{
	/// <summary>
	/// Description of NurlParams_tests.
	/// </summary>
	/// 
	
	[TestFixture]
	public class NurlParams_tests
	{
		static string get_url = "GET URL";
		static string get_url_error = "ERROR : USAGE get -url \"YourUrl\"";
		
		static string get_url_save = "GET URL SAVE";
		static string get_url_save_error = "ERROR : USAGE get -url \"YourUrl\" -save \"fileName\"";
		
		static string test_url = "TEST URL";
		static string test_url_error = "ERROR : USAGE test -url \"YourUrl\" -times numberOfTimeYouWantToTest";
		
		static string test_url_avg = "TEST URL AVG";
		static string test_url_avg_error = "ERROR : USAGE test -url \"YourUrl\" -times numberOfTimeYouWantToTest -AVG";
		
		static string bad_args = "ERROR : USAGE get -url \"youUrl\" [-save \"youFile\"] OR test -url \"youUrl\" -times numberOfTimeYouWantToTest [-avg]";
		
		public NurlParams_tests()
		{
		}
		
		
		[Test]
		public void Should_return_a_string(){
			NurlParams param = new NurlParams();
			string response = param.SelectNurlByParameters(param.testGetUrl());
			Assert.AreEqual(response.GetType(), typeof(string));
		}
		
		
		[Test]
		public void Should_return_get_url(){
			NurlParams param = new NurlParams();
			string response = param.SelectNurlByParameters(param.testGetUrl());
			Assert.AreEqual(response, get_url);
		}
		
		[Test]
		public void Should_return_get_url_error(){
			NurlParams param = new NurlParams();
			string response = param.SelectNurlByParameters(param.testGetUrlBad());
			Assert.AreEqual(response, get_url_error);
		}
		
		
		[Test]
		public void Should_return_get_url_save(){
			NurlParams param = new NurlParams();
			string response = param.SelectNurlByParameters(param.testGetUrlSave());
			Assert.AreEqual(response, get_url_save);
		}
		
		[Test]
		public void Should_return_get_url_save_error(){
			NurlParams param = new NurlParams();
			string response = param.SelectNurlByParameters(param.testGetUrlSaveBad());
			Assert.AreEqual(response, get_url_save_error);
		}
		
		
		[Test]
		public void Should_return_test_url(){
			NurlParams param = new NurlParams();
			string response = param.SelectNurlByParameters(param.testTestUrl());
			Assert.AreEqual(response, test_url);
		}
		
		[Test]
		public void Should_return_test_url_error(){
			NurlParams param = new NurlParams();
			string response = param.SelectNurlByParameters(param.testTestUrlBad());
			Assert.AreEqual(response, test_url_error);
		}
		
		
		[Test]
		public void Should_return_test_url_avg(){
			NurlParams param = new NurlParams();
			string response = param.SelectNurlByParameters(param.testTestUrlAverage());
			Assert.AreEqual(response, test_url_avg);
		}
		
		[Test]
		public void Should_return_test_url_avg_error(){
			NurlParams param = new NurlParams();
			string response = param.SelectNurlByParameters(param.testTestUrlAverageBad());
			Assert.AreEqual(response, test_url_avg_error);
		}
		
		
		[Test]
		public void Should_return_bad_args_1(){
			NurlParams param = new NurlParams();
			string response = param.SelectNurlByParameters(param.testBadSize());
			Assert.AreEqual(response, bad_args);
		}
		
		[Test]
		public void Should_return_bad_args_2(){
			NurlParams param = new NurlParams();
			string response = param.SelectNurlByParameters(param.testBadArgs());
			Assert.AreEqual(response, bad_args);
		}
		
		
		
	}
}
