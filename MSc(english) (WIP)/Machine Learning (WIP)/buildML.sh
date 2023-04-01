echo "Generating PDF for Machine Learning"
echo $(pandoc --resource-path=src:src/images src/*.md -o ml.pdf -f markdown-implicit_figures)
