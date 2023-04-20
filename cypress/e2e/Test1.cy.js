import HtmlPage from '../PageObj/HtmlPObj'
describe('template spec', () => {
  it('passes', () => {
    cy.visit('../../page/HtmlPage.html')
HtmlPage.selectCheckBox(12312312);
HtmlPage.selectRadioBox(123);
HtmlPage.typeInTextbox('12');
HtmlPage.selectRadioBox(123);
HtmlPage.selectCheckBox(213);
HtmlPage.selectCheckBox(123);
HtmlPage.selectCheckBox(123);
cy.wait(2000);
  })
})
