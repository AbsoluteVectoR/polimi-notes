echo "Generating PDF for Formal Languages and Compilers"
echo $(pandoc --resource-path=src:src/images src/*.md -o flc.pdf -f markdown-implicit_figures)
