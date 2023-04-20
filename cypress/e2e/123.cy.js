import HtmlPage from '../PageObj/HtmlPObj'
describe('template spec', () => {
  it('passes', () => {
    cy.visit('../../page/HtmlPage.html')
HtmlPage.selectCheckBox(1);
HtmlPage.selectRadioBox(3);
HtmlPage.typeInTextbox('23123123123123123123123123111111222222222222222222222222222222222222222222222222222222222222222223');
HtmlPage.selectRadioBox(1);
HtmlPage.selectCheckBox(2);
HtmlPage.selectCheckBox(3);
HtmlPage.selectCheckBox(4);
cy.wait(2000);
  })
})
