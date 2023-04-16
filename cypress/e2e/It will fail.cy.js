import HtmlPage from '../PageObj/HtmlPObj'
describe('template spec', () => {
  it('passes', () => {
    cy.visit('../../page/siteHtml.html')
HtmlPage.selectCheckBox(3);
HtmlPage.selectRadioBox(4);
HtmlPage.selectCheckBox(6);
HtmlPage.typeInTextbox('asdw');
cy.wait(2000);
  })
})
