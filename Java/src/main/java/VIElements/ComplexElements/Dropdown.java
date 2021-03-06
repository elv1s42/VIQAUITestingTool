package VIElements.ComplexElements;

import VIElements.BaseClasses.Selector;
import VIElements.Interfaces.IDropDown;
import VIElements.SimpleElements.Clickable;
import org.openqa.selenium.By;
import org.openqa.selenium.WebElement;

import java.util.ArrayList;
import java.util.List;
import org.openqa.selenium.support.ui.Select;

/**
 * Created by roman.i on 27.10.2014.
 */
public class Dropdown extends Selector<Clickable> implements IDropDown {
    protected By _rootLocator = null;

    public Dropdown() throws Exception{ super(); TypeName = "Dropdown";}
    public Dropdown(String name) throws Exception { super(name); }
    public Dropdown(String name, String cssSelector) throws Exception { super(name, cssSelector); }
    public Dropdown(String name, By rootLocator, By byLocator) throws Exception { super(name, byLocator); _rootLocator = rootLocator; }
    public Dropdown(String name, By byLocator) throws Exception { super(name, byLocator); }
    public Dropdown(By byLocator) throws Exception { super(byLocator); }
    public Dropdown(String name, WebElement webElement) throws Exception { super(name, webElement); }
    public Dropdown(WebElement webElement) throws Exception { super(webElement); }

    @Override
    protected void selectAction(String name) throws Exception {
        if (_rootLocator != null) {
            getWebDriver().findElement(_rootLocator).click();
            getElement(name).click();
        }
        else
            new Select(getWebDriver().findElement(getLocator())).selectByValue(name);
    }

}
