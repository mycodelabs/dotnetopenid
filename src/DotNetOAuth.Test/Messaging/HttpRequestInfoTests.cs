﻿//-----------------------------------------------------------------------
// <copyright file="HttpRequestInfoTests.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotNetOAuth.Test.Messaging {
	using System.Web;
	using DotNetOAuth.Messaging;
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class HttpRequestInfoTests : TestBase {
		[TestMethod]
		public void CtorRequest() {
			HttpRequest request = new HttpRequest("file", "http://someserver?a=b", "a=b");
			////request.Headers["headername"] = "headervalue"; // PlatformNotSupportedException prevents us mocking this up
			HttpRequestInfo info = new HttpRequestInfo(request);
			Assert.AreEqual(request.Headers["headername"], info.Headers["headername"]);
			Assert.AreEqual(request.Url.Query, info.Query);
			Assert.AreEqual(request.QueryString["a"], info.QueryString["a"]);
			Assert.AreEqual(request.Url, info.Url);
			Assert.AreEqual(request.HttpMethod, info.HttpMethod);
		}

		/// <summary>
		/// Checks that a property dependent on another null property
		/// doesn't generate a NullReferenceException.
		/// </summary>
		[TestMethod]
		public void QueryBeforeSettingUrl() {
			HttpRequestInfo info = new HttpRequestInfo();
			Assert.IsNull(info.Query);
		}
	}
}