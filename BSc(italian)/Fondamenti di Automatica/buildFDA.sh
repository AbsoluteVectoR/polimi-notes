echo "Generating PDF for Fondamenti di Automatica"
echo $(pandoc --resource-path=src:src/images src/*.md -o fda.pdf  -f markdown-implicit_figures)
