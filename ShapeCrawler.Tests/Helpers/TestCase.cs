﻿using System.Globalization;
using System.IO;

namespace ShapeCrawler.Tests.Helpers;

public class TestCase
{
    private IPresentation pres;
    private int? shapeId;
    private readonly string caseName;

    public TestCase(string caseName)
    {
        this.caseName = caseName;
    }

    public override string ToString()
    {
        return this.caseName;
    }

    public int SlideNumber { get; set; }
    public string PresentationName { get; set; }
    public string ShapeName { get; set; }

    public IPresentation Presentation
    {
        get
        {
            if (this.pres != null)
            {
                return this.pres;
            }
            
            var stream = TestHelper.GetStream(this.PresentationName);
            this.pres = SCPresentation.Open(stream);

            return this.pres;
        }
    }

    public IAutoShape AutoShape
    {
        get
        {
            var slide = this.Presentation.Slides[this.SlideNumber - 1];

            var autoShape = this.ShapeName == null
                ? slide.Shapes.GetById<IAutoShape>(this.shapeId.Value)
                : slide.Shapes.GetByName<IAutoShape>(this.ShapeName);

            return autoShape;          
        }
    }

    public void SetPresentation(MemoryStream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
        this.pres = SCPresentation.Open(stream);
    }
}

public class TestCase<T1>
{
    private readonly int testCaseNumber;
    public T1 Param1 { get; }

    public TestCase(int testCaseNumber, T1 param1)
    {
        this.testCaseNumber = testCaseNumber;
        this.Param1 = param1;
    }

    public override string ToString()
    {
        return this.testCaseNumber.ToString(NumberFormatInfo.CurrentInfo);
    }
}

public class TestCase<T1, T2>
{
    private readonly int testCaseNumber;
    public T1 Param1 { get; }
    public T2 Param2 { get; }

    public TestCase(int testCaseNumber, T1 param1, T2 param2)
    {
        this.testCaseNumber = testCaseNumber;
        this.Param1 = param1;
        this.Param2 = param2;
    }

    public override string ToString()
    {
        return this.testCaseNumber.ToString(NumberFormatInfo.CurrentInfo);
    }
}