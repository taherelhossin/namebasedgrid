﻿/*
------------------------------------------------------------------------------
This source file is a part of Name-Based Grid.

Copyright (c) 2015 Florian Haag

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
------------------------------------------------------------------------------
 */
using System;
using System.Windows;

namespace NameBasedGrid
{
	/// <summary>
	/// Defines a column or a row in a <see cref="T:NameBasedGrid"/>.
	/// </summary>
	/// <remarks>
	/// <para>A <see cref="ColumnOrRow"/> instance defines a column or a row in a <see cref="T:NameBasedGrid"/> that occupies some space of its own and can be used to position visual elements.</para>
	/// <para>As <see cref="ColumnOrRow"/> inherits the <see cref="ColumnOrRowBase.Name"/> property from <see cref="ColumnOrRowBase"/>, it may be assigned a name.
	///   The name can be used to refer to the column or row when placing elements.
	///   If a <see cref="ColumnOrRow"/> instance does not have a name, it cannot be referred to, but it will still occupy some space.</para>
	/// <para>The layout-specific properties such as <see cref="Size"/> or <see cref="SharedSizeGroup"/> work analogously to the respective properties of a <see cref="System.Windows.Controls.ColumnDefinition"/> or a <see cref="System.Windows.Controls.RowDefinition"/>.</para>
	/// </remarks>
	public sealed class ColumnOrRow : ColumnOrRowBase
	{
		/// <summary>
		/// Initializes a new instance.
		/// </summary>
		public ColumnOrRow()
		{
		}
		
		/// <summary>
		/// Identifies the <see cref="P:Size"/> property.
		/// </summary>
		/// <seealso cref="P:Size"/>
		public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size",
		                                                                                     typeof(GridLength),
		                                                                                     typeof(ColumnOrRow),
		                                                                                     new FrameworkPropertyMetadata(new GridLength(1.0, GridUnitType.Star), OnSizeChanged));
		
		/// <summary>
		/// Processes a change of the <see cref="P:Size"/> property.
		/// </summary>
		/// <param name="source">The instance whose <see cref="P:Size"/> property was changed.</param>
		/// <param name="e">An object providing some information about the change.</param>
		private static void OnSizeChanged(object source, DependencyPropertyChangedEventArgs e)
		{
			((ColumnOrRow)source).OnSizeChanged(e);
		}
		
		/// <summary>
		/// Processes a change of the <see cref="P:Size"/> property.
		/// </summary>
		/// <param name="e">An object providing some information about the change.</param>
		private void OnSizeChanged(DependencyPropertyChangedEventArgs e)
		{
			OnPropertyChanged(ColumnOrRowProperty.Size);
		}
		
		/// <summary>
		/// The column width or row height.
		/// </summary>
		/// <value>
		/// <para>Gets or sets the size of the column or row.
		///   The size indicates the width for columns and the height for rows.
		///   Hence, it acts accordingly to the properties <see cref="System.Windows.Controls.ColumnDefinition.Width"/> and <see cref="System.Windows.Controls.RowDefinition.Height"/> or the respective <see cref="System.Windows.Controls.Grid"/>-related types.</para>
		/// </value>
		public GridLength Size {
			get {
				return (GridLength)GetValue(SizeProperty);
			}
			set {
				SetValue(SizeProperty, value);
			}
		}
		
		/// <summary>
		/// Identifies the <see cref="P:SharedSizeGroup"/> property.
		/// </summary>
		/// <seealso cref="P:SharedSizeGroup"/>
		public static readonly DependencyProperty SharedSizeGroupProperty = DependencyProperty.Register("SharedSizeGroup",
		                                                                                                typeof(string),
		                                                                                                typeof(ColumnOrRow),
		                                                                                                new FrameworkPropertyMetadata(OnSharedSizeGroupChanged));
		
		/// <summary>
		/// Processes a change of the <see cref="P:SharedSizeGroup"/> property.
		/// </summary>
		/// <param name="source">The instance whose <see cref="P:SharedSizeGroup"/> property was changed.</param>
		/// <param name="e">An object providing some information about the change.</param>
		private static void OnSharedSizeGroupChanged(object source, DependencyPropertyChangedEventArgs e)
		{
			((ColumnOrRow)source).OnSharedSizeGroupChanged(e);
		}
		
		/// <summary>
		/// Processes a change of the <see cref="P:SharedSizeGroup"/> property.
		/// </summary>
		/// <param name="e">An object providing some information about the change.</param>
		private void OnSharedSizeGroupChanged(DependencyPropertyChangedEventArgs e)
		{
			OnPropertyChanged(ColumnOrRowProperty.SharedSizeGroup);
		}
		
		/// <summary>
		/// The name of a shared size group.
		/// </summary>
		/// <value>
		/// <para>Gets or sets a name of a shared size group that the column or row belongs to.
		///   This works analogously to <see cref="System.Windows.Controls.DefinitionBase.SharedSizeGroup"/>.</para>
		/// </value>
		public string SharedSizeGroup {
			get {
				return (string)GetValue(SharedSizeGroupProperty);
			}
			set {
				SetValue(SharedSizeGroupProperty, value);
			}
		}
	}
}
