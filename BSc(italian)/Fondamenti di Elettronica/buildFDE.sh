echo "Generating PDF for Fondamenti di Elettronica"
echo $(pandoc --resource-path=src:src/images src/*.md -o fde.pdf  -f markdown-implicit_figures)
