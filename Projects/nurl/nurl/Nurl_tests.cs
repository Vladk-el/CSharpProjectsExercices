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
		
		static string fakeFile = "fake.txt";
		static string realFile = "real.txt";
		
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
		
		
		
		[Test]
		public void Should_return_a_boolean(){
			Nurl test = new Nurl();
			
			bool response = test.SaveTheContentOfAWebPage(fakeUrl, fakeFile);
			Assert.AreEqual(response.GetType(), typeof(bool));
		}
		
		[Test]
		public void Should_save_the_content_of_a_fake_page_in_a_file(){
			Nurl test = new Nurl();
			
			bool response = test.SaveTheContentOfAWebPage(fakeUrl, fakeFile);
			
			var fullText = System.IO.File.ReadAllText(fakeFile);
			Assert.AreEqual(fullText, errorResponse + "\r\n");
		}
		
		[Test]
		public void Should_save_the_content_of_a_real_page_in_a_file(){
			Nurl test = new Nurl();
			
			bool response = test.SaveTheContentOfAWebPage(fakeUrl, realFile);
			
			var fullText = System.IO.File.ReadAllText(realFile);
			Assert.AreNotEqual(fullText, errorResponse + "\r\n");
		}
		
		
	}
}
