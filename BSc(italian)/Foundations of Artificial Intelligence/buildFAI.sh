echo "Generating PDF for Foundations of AI"
echo $(pandoc --resource-path=src:src/images src/*.md -o fai.pdf -f markdown-implicit_figures)
