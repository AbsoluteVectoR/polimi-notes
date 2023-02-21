echo "Generating PDF for Software Engineering 2"
echo $(pandoc --resource-path=src:src/images src/*.md -o sw2.pdf -f markdown-implicit_figures)
