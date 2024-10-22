using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTaxInvoicePdfGenerate
{
    public class PDFA3Invoice
    {



        public void CreatePDFA3Invoice(
            string pdfFilePath,
            string xmlFilePath,
            string xmlFileName,
            string xmlVersion,
            string documentID,
            string documentOID,
            string outputPath,
            string documentType)
        {
            // =========== Create PDF/A-3U Document =================
            // Create PDF/A-3U writer instance from existing document
            PdfReader reader = new PdfReader(pdfFilePath);
            MemoryStream stream = new MemoryStream();
            Document pdfAdocument = new Document();
            PdfAWriter writer = this.CreatePDFAInstance(pdfAdocument, reader, stream);


            // Create Output Intents
            ICC_Profile icc = ICC_Profile.GetInstance("Resources/sRGB Color Space Profile.icm");
            writer.SetOutputIntents("sRGB IEC61966-2.1", "", "http://www.color.org", "sRGB IEC61966-2.1", icc);



            PdfArray array = new PdfArray();
            writer.ExtraCatalog.Put(new PdfName("AF"), array);


            //============= Create Exchange Invoice =================
            // 1 add xml to document
            PdfFileSpecification contentSpec = this.EmbeddedAttachment(xmlFilePath, xmlFileName,
                    "text/xml", new PdfName("Alternative"), writer, "Tax Invoice XML Data");
            array.Add(contentSpec.Reference);


            //// 2 add Electronic Document XMP Metadata
            string stringExchangeXMP = File.ReadAllText("Resources/EDocument_PDFAExtensionSchema.xml");
            byte[] exchangeXMP = Encoding.ASCII.GetBytes(stringExchangeXMP.Replace("@DocumentType", documentType));
            writer.XmpMetadata = exchangeXMP;


            pdfAdocument.Close();
            reader.Close();
            File.WriteAllBytes(outputPath, stream.ToArray());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetDocument"></param>
        /// <param name="originalDocument"></param>
        /// <param name="os"></param>
        /// <returns></returns>
        public PdfAWriter CreatePDFAInstance(Document targetDocument, PdfReader originalDocument, Stream os)
        {
            PdfAWriter writer = PdfAWriter.GetInstance(targetDocument, os, PdfAConformanceLevel.PDF_A_3U);
            writer.CreateXmpMetadata();

            if (!targetDocument.IsOpen())
                targetDocument.Open();

            PdfContentByte cb = writer.DirectContent; // Holds the PDF data	
            PdfImportedPage page;
            int pageCount = originalDocument.NumberOfPages;
            for (int i = 0; i < pageCount; i++)
            {
                targetDocument.NewPage();
                page = writer.GetImportedPage(originalDocument, i + 1);
                cb.AddTemplate(page, 0, 0);
            }
            return writer;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="mimeType"></param>
        /// <param name="afRelationship"></param>
        /// <param name="writer"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public PdfFileSpecification EmbeddedAttachment(string filePath, string fileName, string mimeType,
            PdfName afRelationship, PdfAWriter writer, string description)
        {
            PdfDictionary parameters = new PdfDictionary();
            parameters.Put(PdfName.MODDATE, new PdfDate(File.GetLastWriteTime(filePath)));
            PdfFileSpecification fileSpec = PdfFileSpecification.FileEmbedded(writer, filePath, fileName, null, mimeType,
                    parameters, 0);
            fileSpec.Put(new PdfName("AFRelationship"), afRelationship);
            writer.AddFileAttachment(description, fileSpec);
            return fileSpec;
        }
    }
}
