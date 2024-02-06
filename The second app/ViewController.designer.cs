// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in Xcode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace The_second_app
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField age { get; set; }

		[Outlet]
		AppKit.NSTextField biggestSalary { get; set; }

		[Outlet]
		AppKit.NSTextField employeeToDelete { get; set; }

		[Outlet]
		AppKit.NSTextField id { get; set; }

		[Outlet]
		AppKit.NSTextField label1 { get; set; }

		[Outlet]
		AppKit.NSTextField name { get; set; }

		[Outlet]
		AppKit.NSTextField salary { get; set; }

		[Outlet]
		AppKit.NSTextField salarySUM { get; set; }

		[Outlet]
		AppKit.NSTextField smallestAge { get; set; }

		[Outlet]
		AppKit.NSTextField surname { get; set; }

		[Action ("button1:")]
		partial void button1 (AppKit.NSButton sender);

		[Action ("delete:")]
		partial void delete (AppKit.NSButton sender);

		[Action ("deleteEmployee:")]
		partial void deleteEmployee (AppKit.NSButton sender);

		[Action ("insert:")]
		partial void insert (AppKit.NSButton sender);

		[Action ("sorted:")]
		partial void sorted (AppKit.NSButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (label1 != null) {
				label1.Dispose ();
				label1 = null;
			}

			if (id != null) {
				id.Dispose ();
				id = null;
			}

			if (name != null) {
				name.Dispose ();
				name = null;
			}

			if (surname != null) {
				surname.Dispose ();
				surname = null;
			}

			if (age != null) {
				age.Dispose ();
				age = null;
			}

			if (salary != null) {
				salary.Dispose ();
				salary = null;
			}

			if (employeeToDelete != null) {
				employeeToDelete.Dispose ();
				employeeToDelete = null;
			}

			if (salarySUM != null) {
				salarySUM.Dispose ();
				salarySUM = null;
			}

			if (smallestAge != null) {
				smallestAge.Dispose ();
				smallestAge = null;
			}

			if (biggestSalary != null) {
				biggestSalary.Dispose ();
				biggestSalary = null;
			}

		}
	}
}
