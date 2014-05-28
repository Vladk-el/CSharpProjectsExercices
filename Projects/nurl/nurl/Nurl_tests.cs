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
		public Nurl_tests()
		{
		}
		
		[Test]
		public void SayHello(){
			var test = "test";
			Assert.AreEqual(test.GetType(), typeof(string));
		}
	}
}
