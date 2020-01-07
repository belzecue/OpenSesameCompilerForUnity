using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace Coffee.hogehoge
{
	[InitializeOnLoad]
	internal class HogeHoge
	{
		static HogeHoge()
		{
			Debug.Log("<b>HogeHoge</b>");
			var miRegister = typeof(UnityEditorInternal.InternalEditorUtility).GetMethod("RegisterPrecompiledAssembly", BindingFlags.NonPublic | BindingFlags.Static);

			Debug.Log("????? "+File.Exists(Path.GetFullPath("Packages/com.coffee.open-sesame-compiler/Editor/Unity.PureCSharpTests.dll")));

			var t0 = Type.GetType("Coffee.OpenSesameCompilers.OpenSesameInstaller, Unity.PureCSharpTests");
			Debug.Log("0 " + t0);

			miRegister.Invoke(null, new[] { "Unity.PureCSharpTests.dll", Path.GetFullPath("Packages/com.coffee.open-sesame-compiler/Editor/Unity.PureCSharpTests.dll") });
			Debug.Log(miRegister);


			System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(Type.GetType("Coffee.OpenSesameCompilers.OpenSesameInstaller, Unity.PureCSharpTests").TypeHandle);

			EditorApplication.delayCall += () =>
			{
				var t2 = Type.GetType("Coffee.OpenSesameCompilers.OpenSesameInstaller, Unity.PureCSharpTests");
				Debug.Log("b " + t2);
			};
			var t = Type.GetType("Coffee.OpenSesameCompilers.OpenSesameInstaller, Unity.PureCSharpTests");
			Debug.Log("a " + t);

		}

		[MenuItem("hogeho/hoge")]
		static void test()
		{

			var t = Type.GetType("Coffee.OpenSesameCompilers.OpenSesameInstaller, Unity.PureCSharpTests");
			Debug.Log(t);
		}
	}
}