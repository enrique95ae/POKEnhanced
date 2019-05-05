using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ZXing;
using ZXing.QrCode;
using ZXing.Common;
using ZXing.OneD;
using ZXing.Net.Mobile.Forms;
using ZXing;
//using System.Drawing;

namespace POKEnhanced2
{
    public partial class QRpage : ContentPage
    {
        ZXingBarcodeImageView barcode;  

        public QRpage(string incUrl)
        {
            InitializeComponent();

            barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
            };
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 300;
            barcode.BarcodeOptions.Height = 300;
            barcode.BarcodeOptions.Margin = 10;
            barcode.BarcodeValue = incUrl;


            this.Content = barcode;
            stackPrinc.Children.Add(barcode);

        }

    }
}
