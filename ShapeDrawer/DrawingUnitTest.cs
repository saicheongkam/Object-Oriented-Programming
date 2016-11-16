using NUnit.Framework;
using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
	[TestFixture ()]
	public class DrawingUnitTest
	{
		[Test ()]
		public void TestDefaultInitialisation ()
		{
			Drawing a = new Drawing();
			Assert.AreEqual (a.background, Color.White);
		}

		[Test ()]
		public void TestInitialiseWithColor ()
		{
			Drawing b = new Drawing (Color.Red);
			Assert.AreEqual (Color.Red, b.background);
		}

		[Test ()]
		public void TestAddShape ()
		{
			Drawing myDrawing = new Drawing();
			int count = myDrawing.ShapeCount;

			Assert.AreEqual (0, count, "Drawing should start with no shapes");

			myDrawing.AddShape (new Rectangle ());
			myDrawing.AddShape (new Circle ());
			count = myDrawing.ShapeCount;

			Assert.AreEqual (2, count, "Adding 2 shapes should increase the count to 2");
		}

		[Test ()]
		public void TestSelectShape()
		{
			Drawing myDrawing = new Drawing ();
			Shape[] testShapes = {
				new Rectangle (Color.Red, 25, 25, 50, 50),
				new Rectangle (Color.Green, 25, 10, 50, 50),
				new Rectangle (Color.Blue, 10, 25, 50, 50)
			};

			foreach (Shape s in testShapes)
				myDrawing.AddShape (s);

			List<Shape> selected;
			Point2D point;

			point = SwinGame.PointAt( 70, 70 );
			myDrawing.SelectShapesAt( point );
			selected = myDrawing.SelectedShapes;
			CollectionAssert.Contains( selected, testShapes[0] );
			Assert.AreEqual( 1, selected.Count );

			point = SwinGame.PointAt( 70, 50 );
			myDrawing.SelectShapesAt( point );
			selected = myDrawing.SelectedShapes;
			CollectionAssert.Contains( selected, testShapes[0] );
			CollectionAssert.Contains( selected, testShapes[1] );
			Assert.AreEqual( 2, selected.Count );

			point = SwinGame.PointAt( 50, 50 );
			myDrawing.SelectShapesAt( point );
			selected = myDrawing.SelectedShapes;
			CollectionAssert.Contains( selected, testShapes[0] );
			CollectionAssert.Contains( selected, testShapes[1] );
			CollectionAssert.Contains( selected, testShapes[2] );
			Assert.AreEqual( 3, selected.Count ); 
		}

		[Test ()]
		public void RemoveShapeTest()
		{
			Drawing myDrawing = new Drawing ();
			int count = myDrawing.ShapeCount;
			Rectangle shape1 = new Rectangle (Color.Red, 50, 50, 50, 50);
			Rectangle shape2 = new Rectangle (Color.Green, 40, 40, 50, 50);
			Rectangle shape3 = new Rectangle (Color.Blue, 30, 30, 50, 50);

			myDrawing.AddShape (shape1);
			myDrawing.AddShape (shape2);
			myDrawing.AddShape (shape3);
			count = myDrawing.ShapeCount;

			Assert.AreEqual (3, count, "Adding 3 shapes should increase the count to 3");

			myDrawing.RemoveShape (shape3);
			count = myDrawing.ShapeCount;

			Assert.AreEqual (2, count, "Removing one shape should decrease the count to 2");
			myDrawing.SelectShapesAt (SwinGame.PointAt (30, 30));
		}

	}
}

