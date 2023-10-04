using HelixToolkit.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
         
        } 


        private void LoadAndDisplayModel()
        {
            OpenFileDialog ofd = new OpenFileDialog();
          //  ofd.Filter = "Wavefront OBJ Files|*.obj,";
            ofd.ShowDialog();
            // Создание модели из файла OBJ
            var reader = new HelixToolkit.Wpf.ObjReader();
            Model3DGroup modelGroup = reader.Read(ofd.FileName);


            var modelVisual3D = new ModelVisual3D();
            foreach (var model in modelGroup.Children)
            {
                var modelVisual = new ModelVisual3D();
                modelVisual.Content = model;
                modelVisual3D.Children.Add(modelVisual);
            }

            viewport.Children.Add(modelVisual3D);
            // ZoomToFit(viewport);

            viewport.ZoomExtents();

        }

        private void Buton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Buton_Click_1(object sender, RoutedEventArgs e)
        {
            
            LoadAndDisplayModel();
            
        }

        //private void ZoomToFit(HelixViewport3D viewport)
        //{
        //    if (viewport.Children.Count == 0)
        //        return;

        //    var bounds = CalculateModelBounds(viewport.Children);
        //    viewport.CameraController.ZoomExtents(bounds);
        //}

        //private Rect3D CalculateModelBounds(Model3D model)
        //{
        //    var bounds = model.Bounds;
        //    var transform = model.Transform;

        //    // Применяем преобразование к границам модели, если оно задано
        //    if (transform != null && !transform.Value.IsIdentity)
        //        bounds.Transform(transform.Value);

        //    return bounds;
        //}



    }
}
