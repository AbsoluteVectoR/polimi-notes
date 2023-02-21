echo "Generating PDF for Algoritmi e Principi dell'Informatica"
echo $(pandoc --resource-path=src:src/images src/*.md -o api.pdf -f markdown-implicit_figures)
