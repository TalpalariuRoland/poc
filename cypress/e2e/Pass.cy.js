import HtmlPage from '../PageObj/HtmlPObj'
describe('template spec', () => {
  it('passes', () => {
    cy.visit('../../page/siteHtml.html')
HtmlPage.selectCheckBox(1);
HtmlPage.selectRadioBox(2);
HtmlPage.selectCheckBox(3);
HtmlPage.typeInTextbox('4');
cy.wait(2000);
  })
})
