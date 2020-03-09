using System;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;


namespace Project
{
    public class DrawObject
    {

        [CommandMethod("Draw")]
        public void project()
        {
        /*
            int userInput_a = 10;
            int userInput_b = 5;
            int userInput_c = 2;
            int length = 10;
            int distance = 2;
         */



            Document doc = Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor edt = doc.Editor;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
         // Takeing "a" value 

        PromptStringOptions prompt_a = new PromptStringOptions("Enter a value: ");
            prompt_a.AllowSpaces = true;

            //get the results of the user input using a PromptResult

            PromptResult result_a = edt.GetString(prompt_a);

            string name_a = result_a.StringResult;
            int userInput_a = Int16.Parse(name_a);

            edt.WriteMessage("a Value: " + userInput_a + "  ");

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Takeing "b" value 

            PromptStringOptions prompt_b = new PromptStringOptions("Enter b value: ");
            prompt_b.AllowSpaces = true;

            //get the results of the user input using b PromptResult

            PromptResult result_b = edt.GetString(prompt_b);

            string name_b = result_b.StringResult;
            int userInput_b = Int16.Parse(name_b);

            edt.WriteMessage("b Value: " + userInput_b + "  ");

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            // Takeing "c" value 

            PromptStringOptions prompt_c = new PromptStringOptions("Enter c value: ");
            prompt_b.AllowSpaces = true;

            //get the results of the user input using b PromptResult

            PromptResult result_c = edt.GetString(prompt_c);

            string name_c = result_c.StringResult;
            int userInput_c = Int16.Parse(name_c);

            edt.WriteMessage("c Value: " + userInput_c + "  ");

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////            

            // Takeing lenth value 

            PromptStringOptions prompt_length = new PromptStringOptions("Enter the length: ");
            prompt_length.AllowSpaces = true;

            //get the results of the user input using b PromptResult

            PromptResult result_length = edt.GetString(prompt_length);

            string name_length = result_length.StringResult;
            int length = Int16.Parse(name_length);

            edt.WriteMessage("length: " + length + "   ");

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            // Takeing Distance value 

            PromptStringOptions prompt_distance = new PromptStringOptions("Enter the distance: ");
            prompt_distance.AllowSpaces = true;

            //get the results of the user input using b PromptResult

            PromptResult result_distance = edt.GetString(prompt_distance);

            string name_distance = result_distance.StringResult;
            int distance = Int16.Parse(name_distance);

            edt.WriteMessage("distance: " + distance + "   ");


            


            for (int i = distance; i<=length;i+=distance)
            {
                Point3d line_01_pt_01 = new Point3d(0, i, 0);
                Point3d line_01_pt_02 = new Point3d(0, i, userInput_a);
                Point3d line_01_pt_03 = new Point3d(userInput_b / 2, i, userInput_a + userInput_c);
                Point3d line_01_pt_04 = new Point3d(userInput_b, i, userInput_a);
                Point3d line_01_pt_05 = new Point3d(userInput_b, i, 0);

                //Line 01: Horizontal
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    try
                    {
                        BlockTable bt;
                        bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                        BlockTableRecord btr;
                        btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                        //Point3d line_01_pt_01 = new Point3d(0, i, 0);
                        //Point3d line_01_pt_02 = new Point3d(0,i, userInput_a);
                        Point3d point_01 = new Point3d(0, i-distance, 0);

                        Line line_01_h = new Line(line_01_pt_01, point_01);

                        btr.AppendEntity(line_01_h);

                        trans.AddNewlyCreatedDBObject(line_01_h, true);
                        trans.Commit();
                    }
                    catch (System.Exception ex)
                    {

                        edt.WriteMessage("Error Encountered:" + ex);
                        trans.Abort();

                    }
                }

                //Line 02
                //Line 02: Horizontal
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    try
                    {
                        BlockTable bt;
                        bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                        BlockTableRecord btr;
                        btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                        //Point3d line_01_pt_01 = new Point3d(0, i, 0);
                        //Point3d line_01_pt_02 = new Point3d(0,i, userInput_a);
                        Point3d point_02 = new Point3d(0, i - distance, userInput_a);

                        Line line_02_h = new Line(line_01_pt_02, point_02);

                        btr.AppendEntity(line_02_h);

                        trans.AddNewlyCreatedDBObject(line_02_h, true);
                        trans.Commit();
                    }
                    catch (System.Exception ex)
                    {

                        edt.WriteMessage("Error Encountered:" + ex);
                        trans.Abort();

                    }
                }

                //Line 03: Horizontal
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    try
                    {
                        BlockTable bt;
                        bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                        BlockTableRecord btr;
                        btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                        //Point3d line_01_pt_01 = new Point3d(0, i, 0);
                        //Point3d line_01_pt_02 = new Point3d(0,i, userInput_a);
                        Point3d point_03 = new Point3d(userInput_b / 2, i - distance, userInput_a + userInput_c);

                        Line line_03_h = new Line(line_01_pt_03, point_03);

                        btr.AppendEntity(line_03_h);

                        trans.AddNewlyCreatedDBObject(line_03_h, true);
                        trans.Commit();
                    }
                    catch (System.Exception ex)
                    {

                        edt.WriteMessage("Error Encountered:" + ex);
                        trans.Abort();

                    }
                }

                //Line 04: Horizontal
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    try
                    {
                        BlockTable bt;
                        bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                        BlockTableRecord btr;
                        btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                        //Point3d line_01_pt_01 = new Point3d(0, i, 0);
                        //Point3d line_01_pt_02 = new Point3d(0,i, userInput_a);
                        Point3d point_04 = new Point3d(userInput_b, i-distance, userInput_a);

                        Line line_04_h = new Line(line_01_pt_04, point_04);

                        btr.AppendEntity(line_04_h);

                        trans.AddNewlyCreatedDBObject(line_04_h, true);
                        trans.Commit();
                    }
                    catch (System.Exception ex)
                    {

                        edt.WriteMessage("Error Encountered:" + ex);
                        trans.Abort();

                    }
                }

                //Line 05: Horizontal
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    try
                    {
                        BlockTable bt;
                        bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                        BlockTableRecord btr;
                        btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                        //Point3d line_01_pt_01 = new Point3d(0, i, 0);
                        //Point3d line_01_pt_02 = new Point3d(0,i, userInput_a);
                        Point3d point_05 = new Point3d(userInput_b, i-distance, 0);

                        Line line_05_h = new Line(line_01_pt_05, point_05);

                        btr.AppendEntity(line_05_h);

                        trans.AddNewlyCreatedDBObject(line_05_h, true);
                        trans.Commit();
                    }
                    catch (System.Exception ex)
                    {

                        edt.WriteMessage("Error Encountered:" + ex);
                        trans.Abort();

                    }
                }
































































                //Line 01 
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {


                    try
                    {
                        BlockTable bt;
                        bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                        BlockTableRecord btr;
                        btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                        //Point3d line_01_pt_01 = new Point3d(0, i, 0);
                        //Point3d line_01_pt_02 = new Point3d(0,i, userInput_a);

                        Line line_01 = new Line(line_01_pt_01, line_01_pt_02);

                        btr.AppendEntity(line_01);

                        trans.AddNewlyCreatedDBObject(line_01, true);
                        trans.Commit();
                    }
                    catch (System.Exception ex)
                    {

                        edt.WriteMessage("Error Encountered:" + ex);
                        trans.Abort();

                    }
                }


                //Line 02
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    try
                    {
                        BlockTable bt;
                        bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                        BlockTableRecord btr;
                        btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                        //Point3d line_01_pt_02 = new Point3d(0, i, userInput_a);
                        //Point3d line_01_pt_03 = new Point3d(userInput_b / 2, i, userInput_a + userInput_c);

                        Line line_02 = new Line(line_01_pt_02, line_01_pt_03);

                        btr.AppendEntity(line_02);

                        trans.AddNewlyCreatedDBObject(line_02, true);
                        trans.Commit();

                    }
                    catch (System.Exception ex)
                    {

                        edt.WriteMessage("Error Encountered:" + ex);
                        trans.Abort();

                    }
                }

                //Line 03

                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    try
                    {
                        BlockTable bt;
                        bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                        BlockTableRecord btr;
                        btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                        //Point3d line_01_pt_03 = new Point3d(userInput_b / 2, i, userInput_a + userInput_c);
                        //Point3d line_01_pt_04 = new Point3d(userInput_b, i, userInput_a);

                        Line line_03 = new Line(line_01_pt_03, line_01_pt_04);

                        btr.AppendEntity(line_03);

                        trans.AddNewlyCreatedDBObject(line_03, true);
                        trans.Commit();

                    }
                    catch (System.Exception ex)
                    {

                        edt.WriteMessage("Error Encountered:" + ex);
                        trans.Abort();

                    }
                }

                //Line 04
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    try
                    {
                        BlockTable bt;
                        bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                        BlockTableRecord btr;
                        btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                        //Point3d line_01_pt_04 = new Point3d(userInput_b, i, userInput_a);
                        //Point3d line_01_pt_05 = new Point3d(userInput_b, i,0);

                        Line line_04 = new Line(line_01_pt_04, line_01_pt_05);

                        btr.AppendEntity(line_04);

                        trans.AddNewlyCreatedDBObject(line_04, true);
                        trans.Commit();

                    }
                    catch (System.Exception ex)
                    {

                        edt.WriteMessage("Error Encountered:" + ex);
                        trans.Abort();

                    }
                }


            }

            
            //First Frame
            //Line 01 
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    Point3d line_01_pt_01 = new Point3d(0, 0, 0);
                    Point3d line_01_pt_02 = new Point3d(0, 0, userInput_a);

                    Line line_01 = new Line(line_01_pt_01, line_01_pt_02);

                    btr.AppendEntity(line_01);

                    trans.AddNewlyCreatedDBObject(line_01, true);
                    trans.Commit();

                }
                catch (System.Exception ex)
                {

                    edt.WriteMessage("Error Encountered:" + ex);
                    trans.Abort();

                }
            }

            //Line 02
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    Point3d line_01_pt_02 = new Point3d(0, 0, userInput_a);
                    Point3d line_01_pt_03 = new Point3d(userInput_b/2, 0, userInput_a + userInput_c);

                    Line line_02 = new Line(line_01_pt_02, line_01_pt_03);

                    btr.AppendEntity(line_02);

                    trans.AddNewlyCreatedDBObject(line_02, true);
                    trans.Commit();

                }
                catch (System.Exception ex)
                {

                    edt.WriteMessage("Error Encountered:" + ex);
                    trans.Abort();

                }
            }

            //Line 03

            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    Point3d line_01_pt_03 = new Point3d(userInput_b / 2, 0, userInput_a + userInput_c);
                    Point3d line_01_pt_04 = new Point3d(userInput_b,0, userInput_a);

                    Line line_03 = new Line(line_01_pt_03, line_01_pt_04);

                    btr.AppendEntity(line_03);

                    trans.AddNewlyCreatedDBObject(line_03, true);
                    trans.Commit();

                }
                catch (System.Exception ex)
                {

                    edt.WriteMessage("Error Encountered:" + ex);
                    trans.Abort();

                }
            }

            //Line 04
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                try
                {
                    BlockTable bt;
                    bt = trans.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;

                    BlockTableRecord btr;
                    btr = trans.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;

                    Point3d line_01_pt_04 = new Point3d(userInput_b, 0, userInput_a);
                    Point3d line_01_pt_05 = new Point3d(userInput_b, 0, 0);

                    Line line_04 = new Line(line_01_pt_04, line_01_pt_05);

                    btr.AppendEntity(line_04);

                    trans.AddNewlyCreatedDBObject(line_04, true);
                    trans.Commit();

                }
                catch (System.Exception ex)
                {

                    edt.WriteMessage("Error Encountered:" + ex);
                    trans.Abort();

                }
            }


            

    

        }
    }
}
