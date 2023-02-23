echo "Generating PDF for Probabilitá e Statistica per l'informatica"
echo $(pandoc --resource-path=src:src/images src/*.md -o psi.pdf -f markdown-implicit_figures)
