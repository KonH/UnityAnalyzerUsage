using UnityEngine;

namespace UnityAnalyzerUsage {
	public sealed class GenericTest<TOuter1, TOuter2> where TOuter2 : Component {
		// Direct component type, no warnings
		public static void ValidCase1(GameObject go) {
			go.GetComponent<Transform>();
		}

		// Direct non-component type, valid warning
		public static void ValidCase2(GameObject go) {
			go.GetComponent<string>();
		}

		// Generic non-component type from outer scope, valid warning
		public static void ValidCase3(GameObject go) {
			go.GetComponent<TOuter1>();
		}

		// Generic component type from method scope, invalid warning
		public static void InvalidCase1<T>(GameObject go) where T : Component {
			go.GetComponent<T>();
		}

		// Generic component type from outer scope, invalid warning
		public static void InvalidCase3(GameObject go) {
			go.GetComponent<TOuter2>();
		}
	}
}