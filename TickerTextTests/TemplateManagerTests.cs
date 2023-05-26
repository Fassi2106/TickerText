using TickerText.Templates;

namespace TickerTextTests;

[TestClass]
public class TemplateManagerTests
{
    private TemplateManager _templateManager;

    [TestInitialize]
    public void Start()
    {
        _templateManager = new TemplateManager();
        ClearTemplates();
    }

    [TestMethod]
    public void CreateTemplate_ShouldAddNewTemplate()
    {
        var initialCount = _templateManager.GetTemplates().Count;
        
        _templateManager.AddTemplate(CreateTemplate());

        int updatedCount = _templateManager.GetTemplates().Count;
        
        Assert.AreEqual(initialCount+1, updatedCount);
    }

    [TestMethod]
    public void DeleteTemplate_ShouldRemoveTemplate()
    {
        var template = CreateTemplate();
        
        _templateManager.AddTemplate(template);

        int initialCount = _templateManager.GetTemplates().Count;
        
        _templateManager.RemoveTemplate(template);
        
        Assert.AreEqual(initialCount-1, _templateManager.GetTemplates().Count);
    }

    [TestMethod]
    public void GetTemplates_ShouldReturnNoTemplate()
    {
        Assert.AreEqual(0, _templateManager.GetTemplates().Count());
    }

    [TestMethod]
    public void SetSelectedTemplate_ShouldSelectTemplate()
    {
        var template = CreateTemplate();
        
        _templateManager.AddTemplate(template);
        
        _templateManager.SetSelectedTemplate(template);
        
        Assert.AreEqual(template, _templateManager.GetSelectedTemplate());
    }

    private TextTemplate CreateTemplate()
    {
        return new TextTemplate("Test", "Big", ConsoleColor.Black, 100, false);
    }

    private void ClearTemplates()
    {
        while (_templateManager.GetTemplates().Count > 0)
        {
            _templateManager.RemoveTemplate(_templateManager.GetTemplates().First());
        }
    }
}