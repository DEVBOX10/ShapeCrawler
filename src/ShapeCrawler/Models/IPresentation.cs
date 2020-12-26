﻿using System.IO;
using ShapeCrawler.Collections;

namespace ShapeCrawler.Models
{
    /// <summary>
    /// Represents a presentation.
    /// </summary>
    public interface IPresentation
    {
        /// <summary>
        /// Returns slides collection.
        /// </summary>
        EditableCollection<Slide> Slides { get; }

        /// <summary>
        /// Returns slides width in EMUs.
        /// </summary>
        int SlideWidth { get; }

        /// <summary>
        /// Returns slides height in EMUs.
        /// </summary>
        int SlideHeight { get; }

        /// <summary>
        /// Saves the presentation in specified file path.
        /// </summary>
        /// <param name="filePath"></param>
        void SaveAs(string filePath);

        /// <summary>
        /// Saves the presentation in specified stream.
        /// </summary>
        void SaveAs(Stream stream);

        /// <summary>
        /// Saves and closes the current presentation.
        /// </summary>
        void Close();
    }
}