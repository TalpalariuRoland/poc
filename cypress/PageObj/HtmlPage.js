class HtmlPage {
    elements={
        checkBoxLocator: () => cy.get('input[type="checkbox"]'),
        radioBoxLocator: () => cy.get('input[type="radio"]'),
        textBoxLocator: () => cy.get('input[name="TextBox"]')
    }

    selectCheckBox(number) {
        this.elements.checkBoxLocator().then((arrayOfBoxes)=>{
            cy.wrap(arrayOfBoxes[number-1]).click();
        })
    }

    selectRadioBox(number) {
        this.elements.radioBoxLocator().then((arrayOfRadios)=>{
            cy.wrap(arrayOfRadios[number-1]).click();
        })
    }

    typeInTextbox(string){
        this.elements.textBoxLocator().type(string);
    }

}
export default new HtmlPage(); 