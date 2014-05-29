/*
 * Created by SharpDevelop.
 * User: Vladk
 * Date: 14/05/2014
 * Time: 11:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using NUnit.Framework;

namespace nurl
{
	/// <summary>
	/// Description of Nurl_tests.
	/// </summary>
	/// 
	[TestFixture]
	public class Nurl_tests
	{
		
		static string fakeUrl = "http://fake";
		static string realUrl = "http://dametenebra.com/";
		
		static string errorResponse = "<h1>hello</h1>";
		
		
		public Nurl_tests()
		{
		}
		
		[Test]
		public void SayHello(){
			var test = "test";
			Assert.AreEqual(test.GetType(), typeof(string));
		}
		
		[Test]
		public void Should_return_the_content_of_a_fake_page_in_string(){
			Nurl test = new Nurl();
			
			string response = test.ShowTheContentOfAWebPage(fakeUrl);
			Assert.AreEqual(response.GetType(), typeof(string));
		}
		
		[Test]
		public void Should_show_the_content_of_a_fake_page(){
			Nurl test = new Nurl();
			
			string response = test.ShowTheContentOfAWebPage(fakeUrl);
			Assert.AreEqual(response, errorResponse);
			
		}
		
		[Test]
		public void Should_show_the_content_of_a_page(){
			Nurl test = new Nurl();
			
			string response = test.ShowTheContentOfAWebPage(realUrl);
			Assert.AreNotEqual(response, errorResponse);
		}
		
		
		
		
	}
}
