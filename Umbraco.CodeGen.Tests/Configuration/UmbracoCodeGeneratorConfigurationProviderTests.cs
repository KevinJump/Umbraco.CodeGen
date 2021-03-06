﻿using System;
using System.IO;
using NUnit.Framework;
using Umbraco.CodeGen.Integration;

namespace Umbraco.CodeGen.Tests.Configuration
{
	[TestFixture]
	public class UmbracoCodeGeneratorConfigurationProviderTests
	{
		[Test]
		public void GetConfiguration_ReturnsConfigurationFromDisk()
		{
			var provider =
				new UmbracoCodeGeneratorConfigurationProvider(Path.Combine(Environment.CurrentDirectory,
					@"..\..\config\codegen.config"));
			var config = provider.GetConfiguration();
			Assert.AreEqual("SomeBaseClass", config.DocumentTypes.BaseClass);
			Assert.AreEqual("String", config.DefaultTypeMapping);
			Assert.AreEqual(true, config.DocumentTypes.GenerateClasses);
			Assert.AreEqual(true, config.DocumentTypes.GenerateXml);
			Assert.AreEqual("Models/DocumentTypes", config.DocumentTypes.ModelPath);
			Assert.AreEqual("MyWeb.Models", config.DocumentTypes.Namespace);
			Assert.AreEqual("pfx", config.DocumentTypes.RemovePrefix);
			Assert.AreEqual(false, config.OverwriteReadOnly);
			Assert.AreNotEqual(0, config.TypeMappings.Count);
			Assert.AreEqual("Int32", config.TypeMappings["1413afcb-d19a-4173-8e9a-68288d2a73b8"]);
		}
	}
}
