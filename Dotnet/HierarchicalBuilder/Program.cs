using static System.Console;

using Demo;

WriteLine("Hierarchical Builder");

Document document = Document.Create("Example Document")
    .Header("Document Header")
    .Section(s => s
        .Header1("Introduction")
        .Paragraph("This is the introduction.")
        .BulletedList(b => b
            .Item("Item 1.1")
            .Item("Item 1.2")
            .Item("Item 1.3")))
    .Section(s => s
        .Header1("Main Body")
        .Paragraph("Paragraph 1 of the main body.")
        .Paragraph("Paragraph 2 of the main body."))
    .Section(s => s
        .Header1("Conclusion")
        .Paragraph("This is the conclusion.")
        .Header2("Contact")
        .Paragraph("Contact us at")
        .Header3("Address")
        .BulletedList(b => b
            .Item("Item 2.1")
            .Item("Item 2.2")))
    .Footer("Document Footer");

WriteLine(document.Print());
