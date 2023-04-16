import HtmlPage from '../PageObj/HtmlPObj'
describe('template spec', () => {
  it('passes', () => {
    cy.visit('../../page/siteHtml.html')
HtmlPage.selectCheckBox(3);
HtmlPage.selectRadioBox(4);
HtmlPage.selectCheckBox(7);
HtmlPage.typeInTextbox('5');
cy.wait(2000);
  })
})
